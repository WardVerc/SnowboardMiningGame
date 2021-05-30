create table __EFMigrationsHistory
(
    MigrationId    nvarchar(150) not null
        constraint PK___EFMigrationsHistory
            primary key,
    ProductVersion nvarchar(32)  not null
)
go

INSERT INTO MijnDatabase.dbo.__EFMigrationsHistory (MigrationId, ProductVersion) VALUES (N'20210514111038_first', N'5.0.5');
INSERT INTO MijnDatabase.dbo.__EFMigrationsHistory (MigrationId, ProductVersion) VALUES (N'20210516183654_removedPasswordColumn', N'5.0.5');