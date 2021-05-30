create table PlayerItems
(
    Id               int identity
        constraint PK_PlayerItems
            primary key,
    PlayerId         int not null
        constraint FK_PlayerItems_Players_PlayerId
            references Players
            on delete cascade,
    ItemId           int not null
        constraint FK_PlayerItems_Items_ItemId
            references Items
            on delete cascade,
    RemainingFuel    int not null,
    RemainingAttack  int not null,
    RemainingDefense int not null
)
go

create index IX_PlayerItems_ItemId
    on PlayerItems (ItemId)
go

create index IX_PlayerItems_PlayerId
    on PlayerItems (PlayerId)
go

INSERT INTO MijnDatabase.dbo.PlayerItems (Id, PlayerId, ItemId, RemainingFuel, RemainingAttack, RemainingDefense) VALUES (4, 2010, 28, 0, 0, 1);
INSERT INTO MijnDatabase.dbo.PlayerItems (Id, PlayerId, ItemId, RemainingFuel, RemainingAttack, RemainingDefense) VALUES (6, 2010, 37, 84, 0, 0);
INSERT INTO MijnDatabase.dbo.PlayerItems (Id, PlayerId, ItemId, RemainingFuel, RemainingAttack, RemainingDefense) VALUES (7, 2010, 29, 0, 0, 120);
INSERT INTO MijnDatabase.dbo.PlayerItems (Id, PlayerId, ItemId, RemainingFuel, RemainingAttack, RemainingDefense) VALUES (8, 2010, 37, 79, 0, 0);
INSERT INTO MijnDatabase.dbo.PlayerItems (Id, PlayerId, ItemId, RemainingFuel, RemainingAttack, RemainingDefense) VALUES (1009, 2010, 25, 0, 479, 0);
INSERT INTO MijnDatabase.dbo.PlayerItems (Id, PlayerId, ItemId, RemainingFuel, RemainingAttack, RemainingDefense) VALUES (1010, 2010, 33, 3, 0, 0);
INSERT INTO MijnDatabase.dbo.PlayerItems (Id, PlayerId, ItemId, RemainingFuel, RemainingAttack, RemainingDefense) VALUES (3016, 2010, 3030, 0, 105, 0);
INSERT INTO MijnDatabase.dbo.PlayerItems (Id, PlayerId, ItemId, RemainingFuel, RemainingAttack, RemainingDefense) VALUES (3018, 2010, 3033, 9, 0, 0);
INSERT INTO MijnDatabase.dbo.PlayerItems (Id, PlayerId, ItemId, RemainingFuel, RemainingAttack, RemainingDefense) VALUES (3020, 2010, 29, 0, 0, 138);
INSERT INTO MijnDatabase.dbo.PlayerItems (Id, PlayerId, ItemId, RemainingFuel, RemainingAttack, RemainingDefense) VALUES (3021, 2010, 36, 71, 0, 0);
INSERT INTO MijnDatabase.dbo.PlayerItems (Id, PlayerId, ItemId, RemainingFuel, RemainingAttack, RemainingDefense) VALUES (3022, 2010, 35, 5, 0, 0);
INSERT INTO MijnDatabase.dbo.PlayerItems (Id, PlayerId, ItemId, RemainingFuel, RemainingAttack, RemainingDefense) VALUES (3023, 2010, 3033, 10, 0, 0);
INSERT INTO MijnDatabase.dbo.PlayerItems (Id, PlayerId, ItemId, RemainingFuel, RemainingAttack, RemainingDefense) VALUES (3026, 2010, 35, 4, 0, 0);
INSERT INTO MijnDatabase.dbo.PlayerItems (Id, PlayerId, ItemId, RemainingFuel, RemainingAttack, RemainingDefense) VALUES (3027, 2010, 24, 0, 297, 0);
INSERT INTO MijnDatabase.dbo.PlayerItems (Id, PlayerId, ItemId, RemainingFuel, RemainingAttack, RemainingDefense) VALUES (3028, 2010, 30, 0, 0, 495);
INSERT INTO MijnDatabase.dbo.PlayerItems (Id, PlayerId, ItemId, RemainingFuel, RemainingAttack, RemainingDefense) VALUES (3029, 2010, 2028, 0, 0, 0);
INSERT INTO MijnDatabase.dbo.PlayerItems (Id, PlayerId, ItemId, RemainingFuel, RemainingAttack, RemainingDefense) VALUES (3030, 2010, 37, 97, 0, 0);