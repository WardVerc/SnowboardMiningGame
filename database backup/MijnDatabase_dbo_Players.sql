create table Players
(
    Id                         int identity
        constraint PK_Players
            primary key,
    Name                       nvarchar(max),
    Money                      int       not null,
    Experience                 int       not null,
    LastActionExecutedDateTime datetime2 not null,
    CurrentFuelPlayerItemId    int
        constraint FK_Players_PlayerItems_CurrentFuelPlayerItemId
            references PlayerItems,
    CurrentAttackPlayerItemId  int
        constraint FK_Players_PlayerItems_CurrentAttackPlayerItemId
            references PlayerItems,
    CurrentDefensePlayerItemId int
        constraint FK_Players_PlayerItems_CurrentDefensePlayerItemId
            references PlayerItems
)
go

create index IX_Players_CurrentAttackPlayerItemId
    on Players (CurrentAttackPlayerItemId)
go

create index IX_Players_CurrentDefensePlayerItemId
    on Players (CurrentDefensePlayerItemId)
go

create index IX_Players_CurrentFuelPlayerItemId
    on Players (CurrentFuelPlayerItemId)
go

INSERT INTO MijnDatabase.dbo.Players (Id, Name, Money, Experience, LastActionExecutedDateTime, CurrentFuelPlayerItemId, CurrentAttackPlayerItemId, CurrentDefensePlayerItemId) VALUES (1010, N'Ronny King', 12345, 200, N'0001-01-01 00:00:00.0000000', null, null, null);
INSERT INTO MijnDatabase.dbo.Players (Id, Name, Money, Experience, LastActionExecutedDateTime, CurrentFuelPlayerItemId, CurrentAttackPlayerItemId, CurrentDefensePlayerItemId) VALUES (1011, N'Jimmy B', 100, 0, N'0001-01-01 00:00:00.0000000', null, null, null);
INSERT INTO MijnDatabase.dbo.Players (Id, Name, Money, Experience, LastActionExecutedDateTime, CurrentFuelPlayerItemId, CurrentAttackPlayerItemId, CurrentDefensePlayerItemId) VALUES (1012, N'Firmin Crets', 100000, 2000, N'0001-01-01 00:00:00.0000000', null, null, null);
INSERT INTO MijnDatabase.dbo.Players (Id, Name, Money, Experience, LastActionExecutedDateTime, CurrentFuelPlayerItemId, CurrentAttackPlayerItemId, CurrentDefensePlayerItemId) VALUES (1013, N'Filip Mars', 500, 5, N'0001-01-01 00:00:00.0000000', null, null, null);
INSERT INTO MijnDatabase.dbo.Players (Id, Name, Money, Experience, LastActionExecutedDateTime, CurrentFuelPlayerItemId, CurrentAttackPlayerItemId, CurrentDefensePlayerItemId) VALUES (2010, N'wardvercruyssen', 3154, 3485, N'2021-05-29 17:37:14.6170796', 3030, 3027, 3028);
INSERT INTO MijnDatabase.dbo.Players (Id, Name, Money, Experience, LastActionExecutedDateTime, CurrentFuelPlayerItemId, CurrentAttackPlayerItemId, CurrentDefensePlayerItemId) VALUES (3010, N'test', 6, 4, N'2021-05-29 13:01:44.1012316', null, null, null);