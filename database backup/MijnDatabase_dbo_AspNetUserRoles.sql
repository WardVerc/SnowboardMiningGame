create table AspNetUserRoles
(
    UserId nvarchar(450) not null
        constraint FK_AspNetUserRoles_AspNetUsers_UserId
            references AspNetUsers
            on delete cascade,
    RoleId nvarchar(450) not null
        constraint FK_AspNetUserRoles_AspNetRoles_RoleId
            references AspNetRoles
            on delete cascade,
    constraint PK_AspNetUserRoles
        primary key (UserId, RoleId)
)
go

create index IX_AspNetUserRoles_RoleId
    on AspNetUserRoles (RoleId)
go

INSERT INTO MijnDatabase.dbo.AspNetUserRoles (UserId, RoleId) VALUES (N'a77bd178-41bc-4218-a217-7990aa22be4a', N'fb8406a5-bcd8-43fc-b729-139a33cd7c5a');