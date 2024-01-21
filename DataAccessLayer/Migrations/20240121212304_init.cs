using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            // create uuid-ossp extension for postgresql
            migrationBuilder.Sql("CREATE EXTENSION IF NOT EXISTS \"uuid-ossp\";");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "Hospitals",
                columns: table => new
                {
                    UId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Coordinate = table.Column<string>(type: "text", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uuid", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: false),
                    District = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Mobile = table.Column<string>(type: "text", nullable: false),
                    ZipCode = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitals", x => x.UId);
                });

            migrationBuilder.CreateTable(
                name: "LoginAttempts",
                columns: table => new
                {
                    UId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    IPAddress = table.Column<string>(type: "text", nullable: false),
                    Count = table.Column<int>(type: "integer", nullable: false),
                    ResetTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginAttempts", x => x.UId);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    UId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.UId);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    UId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    OrganizationId = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Mail = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Size = table.Column<int>(type: "integer", nullable: false),
                    Weight = table.Column<int>(type: "integer", nullable: false),
                    BodyMassIndex = table.Column<int>(type: "integer", nullable: false),
                    BMI = table.Column<int>(type: "integer", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.UId);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    UId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    IPAddress = table.Column<string>(type: "text", nullable: false),
                    AccessToken = table.Column<string>(type: "text", nullable: false),
                    RefreshToken = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.UId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Mobile = table.Column<string>(type: "text", nullable: false),
                    UserStatusEnum = table.Column<int>(type: "integer", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    UserImage = table.Column<string>(type: "text", nullable: true),
                    OrganizationId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UId);
                });

            migrationBuilder.CreateTable(
                name: "DiseaseHistories",
                columns: table => new
                {
                    UId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    OrganizationId = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Explonation = table.Column<string>(type: "text", nullable: false),
                    PatientUId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiseaseHistories", x => x.UId);
                    table.ForeignKey(
                        name: "FK_DiseaseHistories_Patients_PatientUId",
                        column: x => x.PatientUId,
                        principalTable: "Patients",
                        principalColumn: "UId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DrugHistories",
                columns: table => new
                {
                    UId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    OrganizationId = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    StartingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DoctorComment = table.Column<string>(type: "text", nullable: false),
                    PatientUId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugHistories", x => x.UId);
                    table.ForeignKey(
                        name: "FK_DrugHistories_Patients_PatientUId",
                        column: x => x.PatientUId,
                        principalTable: "Patients",
                        principalColumn: "UId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IrregularVisitHistories",
                columns: table => new
                {
                    UId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    OrganizationId = table.Column<Guid>(type: "uuid", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    VKI = table.Column<int>(type: "integer", nullable: false),
                    EWL = table.Column<int>(type: "integer", nullable: false),
                    Img = table.Column<List<string>>(type: "text[]", nullable: false),
                    BloadSituation = table.Column<string>(type: "text", nullable: false),
                    DoctorComment = table.Column<string>(type: "text", nullable: false),
                    PatientUId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IrregularVisitHistories", x => x.UId);
                    table.ForeignKey(
                        name: "FK_IrregularVisitHistories_Patients_PatientUId",
                        column: x => x.PatientUId,
                        principalTable: "Patients",
                        principalColumn: "UId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PeriodicVisitHistories",
                columns: table => new
                {
                    UId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    OrganizationId = table.Column<Guid>(type: "uuid", nullable: true),
                    VKI = table.Column<int>(type: "integer", nullable: false),
                    EWL = table.Column<int>(type: "integer", nullable: false),
                    Img = table.Column<List<string>>(type: "text[]", nullable: false),
                    BloadSituation = table.Column<string>(type: "text", nullable: false),
                    DoctorComment = table.Column<string>(type: "text", nullable: false),
                    PatientUId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodicVisitHistories", x => x.UId);
                    table.ForeignKey(
                        name: "FK_PeriodicVisitHistories_Patients_PatientUId",
                        column: x => x.PatientUId,
                        principalTable: "Patients",
                        principalColumn: "UId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostOps",
                columns: table => new
                {
                    UId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    DoctorId = table.Column<string>(type: "text", nullable: false),
                    DoctorComment = table.Column<string>(type: "text", nullable: false),
                    SurgeryType = table.Column<string>(type: "text", nullable: false),
                    Drenaj = table.Column<int>(type: "integer", nullable: false),
                    SurgeryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uuid", nullable: true),
                    ConsultedMedications = table.Column<List<string>>(type: "text[]", nullable: false),
                    SupplimentedMedications = table.Column<List<string>>(type: "text[]", nullable: false),
                    PatientUId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostOps", x => x.UId);
                    table.ForeignKey(
                        name: "FK_PostOps_Patients_PatientUId",
                        column: x => x.PatientUId,
                        principalTable: "Patients",
                        principalColumn: "UId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PreOps",
                columns: table => new
                {
                    UId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    TargetWeight = table.Column<int>(type: "integer", nullable: false),
                    DoctorId = table.Column<string>(type: "text", nullable: false),
                    SurgeryType = table.Column<string>(type: "text", nullable: false),
                    SurgeryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uuid", nullable: true),
                    ConsultedSurgeryTypes = table.Column<List<string>>(type: "text[]", nullable: false),
                    SupplimentedSurgeryTypes = table.Column<List<string>>(type: "text[]", nullable: false),
                    AssistantDoctors = table.Column<List<string>>(type: "text[]", nullable: false),
                    PatientUId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreOps", x => x.UId);
                    table.ForeignKey(
                        name: "FK_PreOps_Patients_PatientUId",
                        column: x => x.PatientUId,
                        principalTable: "Patients",
                        principalColumn: "UId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SurgeryHistories",
                columns: table => new
                {
                    UId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    OrganizationId = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DoctorComment = table.Column<string>(type: "text", nullable: false),
                    PatientUId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurgeryHistories", x => x.UId);
                    table.ForeignKey(
                        name: "FK_SurgeryHistories_Patients_PatientUId",
                        column: x => x.PatientUId,
                        principalTable: "Patients",
                        principalColumn: "UId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiseaseHistories_PatientUId",
                table: "DiseaseHistories",
                column: "PatientUId");

            migrationBuilder.CreateIndex(
                name: "IX_DrugHistories_PatientUId",
                table: "DrugHistories",
                column: "PatientUId");

            migrationBuilder.CreateIndex(
                name: "IX_IrregularVisitHistories_PatientUId",
                table: "IrregularVisitHistories",
                column: "PatientUId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodicVisitHistories_PatientUId",
                table: "PeriodicVisitHistories",
                column: "PatientUId");

            migrationBuilder.CreateIndex(
                name: "IX_PostOps_PatientUId",
                table: "PostOps",
                column: "PatientUId");

            migrationBuilder.CreateIndex(
                name: "IX_PreOps_PatientUId",
                table: "PreOps",
                column: "PatientUId");

            migrationBuilder.CreateIndex(
                name: "IX_SurgeryHistories_PatientUId",
                table: "SurgeryHistories",
                column: "PatientUId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiseaseHistories");

            migrationBuilder.DropTable(
                name: "DrugHistories");

            migrationBuilder.DropTable(
                name: "Hospitals");

            migrationBuilder.DropTable(
                name: "IrregularVisitHistories");

            migrationBuilder.DropTable(
                name: "LoginAttempts");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "PeriodicVisitHistories");

            migrationBuilder.DropTable(
                name: "PostOps");

            migrationBuilder.DropTable(
                name: "PreOps");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "SurgeryHistories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
