using Microsoft.EntityFrameworkCore;
using VPSyncReviewServer.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Controller 기능 등록
builder.Services.AddControllers();

// 2. DB 연결 문자열 가져오기
var connectionString = builder.Configuration
    .GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException(
        "DefaultConnection을 찾을 수 없습니다."
    );

// 3. ApplicationDbContext 등록
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(connectionString)
);

// 4. 서버 구성 완료
var app = builder.Build();

// 5. Controller 주소 연결
app.MapControllers();

// 6. 서버 실행
app.Run();