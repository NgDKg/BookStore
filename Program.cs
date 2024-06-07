using BookStoreApi.Models;
using BookStoreApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<BookStoreDatabaseSettings>(
    builder.Configuration.GetSection("BookStoreDatabase")); // lấy tông tin kết nối db từ appsettings cho BookStoreDatabaseSettings
builder.Services.AddSingleton<BooksService>();//Dòng lệnh này đăng ký lớp BooksService là dịch vụ singleton trong DI
builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null); //Đăng ký controller MVC, chịu trách nhiệm xử lý các yêu cầu HTTP đến và tạo phản hồi.
builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen();

var app = builder.Build(); // Build app với những option đã khai báo ở trên

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();// Chuyển hướng người dùng từ http(80) -> https(443)

app.UseAuthorization(); // sử dụng middleware ủy quyền

app.MapControllers();// ánh xạ yêu cầu tới controller

app.Run();// bắt đầu chạy ứng dụng
