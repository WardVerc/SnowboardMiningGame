create table AspNetRoles
(
    Id               nvarchar(450) not null
        constraint PK_AspNetRoles
            primary key,
    Discriminator    nvarchar(max) not null,
    Name             nvarchar(256),
    NormalizedName   nvarchar(256),
    ConcurrencyStamp nvarchar(max)
)
go

create unique index RoleNameIndex
    on AspNetRoles (NormalizedName)
    where [NormalizedName] IS NOT NULL
go

INSERT INTO MijnDatabase.dbo.AspNetRoles (Id, Discriminator, Name, NormalizedName, ConcurrencyStamp) VALUES (N'fb8406a5-bcd8-43fc-b729-139a33cd7c5a', N'IdentityRole', N'Admin', N'ADMIN', N'6a91cee6-328d-4e77-ae9b-c0ceb3e0f950');