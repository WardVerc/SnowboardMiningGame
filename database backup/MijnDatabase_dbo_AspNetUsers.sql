create table AspNetUsers
(
    Id                   nvarchar(450) not null
        constraint PK_AspNetUsers
            primary key,
    UserName             nvarchar(256),
    NormalizedUserName   nvarchar(256),
    Email                nvarchar(256),
    NormalizedEmail      nvarchar(256),
    EmailConfirmed       bit           not null,
    PasswordHash         nvarchar(max),
    SecurityStamp        nvarchar(max),
    ConcurrencyStamp     nvarchar(max),
    PhoneNumber          nvarchar(max),
    PhoneNumberConfirmed bit           not null,
    TwoFactorEnabled     bit           not null,
    LockoutEnd           datetimeoffset,
    LockoutEnabled       bit           not null,
    AccessFailedCount    int           not null
)
go

create index EmailIndex
    on AspNetUsers (NormalizedEmail)
go

create unique index UserNameIndex
    on AspNetUsers (NormalizedUserName)
    where [NormalizedUserName] IS NOT NULL
go

INSERT INTO MijnDatabase.dbo.AspNetUsers (Id, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount) VALUES (N'a77bd178-41bc-4218-a217-7990aa22be4a', N'wardvercruyssen', N'WARDVERCRUYSSEN', null, null, 0, N'AQAAAAEAACcQAAAAEPpvvDAxDDfyPyIqm9oW8gBtK3wG6Lcj4IAsJwCfzm3rvmQD8Oa494GgiOzKnvQwmQ==', N'UCK2C2KYM3GO3GL3GEUZFLZ52O25XKYU', N'e52f90a0-3ac9-4bfc-9c43-28591d9c83c6', null, 0, 0, null, 1, 0);
INSERT INTO MijnDatabase.dbo.AspNetUsers (Id, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount) VALUES (N'c8bfd3c0-0234-4444-a737-069c564a314b', N'wardInitialize', N'WARDINITIALIZE', null, null, 0, N'AQAAAAEAACcQAAAAEFhJvpbQnz70IEbOkvWB565mrRWhoigTWqB+bQC2kSk9LNcWvebcCgwyOjr85kHrYA==', N'S4ZND7ZP2JE5KJFJ4GHCSNMLB555A3O2', N'5c497533-7911-40d6-9667-ea5caa753c13', null, 0, 0, null, 1, 0);
INSERT INTO MijnDatabase.dbo.AspNetUsers (Id, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount) VALUES (N'c9bcdeae-0c1d-467f-a50c-c8c3acd0ca10', N'ward', N'WARD', null, null, 0, N'AQAAAAEAACcQAAAAELTH0zVieNgI93R7TVMRLQQvBGd/LJ4HxycPiiBFUulmroZpO/dftjG3hjpu9oTLGg==', N'RU3RVKWKRPRWBSCM7L74YYIQ4VVZD3PY', N'659c1fd0-4a87-4df7-abb9-a0f99a465925', null, 0, 0, null, 1, 0);
INSERT INTO MijnDatabase.dbo.AspNetUsers (Id, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount) VALUES (N'cd97254a-1b63-4fa6-b861-5c2af2b8087b', N'initialize', N'INITIALIZE', null, null, 0, N'AQAAAAEAACcQAAAAEHDgQCCFi6RunGS4AyuO3px0Hlh7O9x2u2L+3itxVVP+qyvEQxPyrrFOWLbQ43FTkQ==', N'CNCSMMHAGLVSKNMXEZ3IZBCOVTK3O7W3', N'498df4fe-218d-4fb8-a12b-f4fe48d3df56', null, 0, 0, null, 1, 0);
INSERT INTO MijnDatabase.dbo.AspNetUsers (Id, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount) VALUES (N'd4689d75-9a71-412c-b1ca-27dc05a26f89', N'test', N'TEST', null, null, 0, N'AQAAAAEAACcQAAAAEB4KNRyWzs39Sr8zDq+Jfg7eDji6GUMyk7C9qwlPle7AE7eG5ECEFvhqnIZLkINA7w==', N'MV47BI2Y2VOGYGGZHUDG5Z76OKLCUHOT', N'e22b8116-7686-4a63-9ccf-4a8d425efab4', null, 0, 0, null, 1, 0);
INSERT INTO MijnDatabase.dbo.AspNetUsers (Id, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount) VALUES (N'fdb015c6-529e-4dc7-9497-ee3c5d1a4fb7', N'paswoordisVergeten', N'PASWOORDISVERGETEN', null, null, 0, N'AQAAAAEAACcQAAAAEOBwknNg5hI12h4De2nwlx/FWRxvMgRPLEimv4FK8bKo8fDoeT/t2TLGI39k9Nrt2Q==', N'HIUVH4HZ7Q6HMXUDGFBZ6BHDM65OLXH6', N'0783a849-a899-4a31-b111-1654d015ff56', null, 0, 0, null, 1, 0);