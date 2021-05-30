create table Items
(
    Id                    int identity
        constraint PK_Items
            primary key,
    Name                  nvarchar(max),
    Description           nvarchar(max),
    Price                 int not null,
    Fuel                  int not null,
    Attack                int not null,
    Defense               int not null,
    ActionCooldownSeconds int not null
)
go

INSERT INTO MijnDatabase.dbo.Items (Id, Name, Description, Price, Fuel, Attack, Defense, ActionCooldownSeconds) VALUES (23, N'Versace snowboard outfit. Most stylish gear of the slopes', null, 10000, 0, 0, 20000, 0);
INSERT INTO MijnDatabase.dbo.Items (Id, Name, Description, Price, Fuel, Attack, Defense, ActionCooldownSeconds) VALUES (24, N'Basic snowboard with flames on it', null, 300, 0, 300, 0, 0);
INSERT INTO MijnDatabase.dbo.Items (Id, Name, Description, Price, Fuel, Attack, Defense, ActionCooldownSeconds) VALUES (25, N'Turbo snowboard with boosters', null, 500, 0, 500, 0, 0);
INSERT INTO MijnDatabase.dbo.Items (Id, Name, Description, Price, Fuel, Attack, Defense, ActionCooldownSeconds) VALUES (26, N'Special snowboard with auto-balancer and nitro', null, 15000, 0, 5000, 0, 0);
INSERT INTO MijnDatabase.dbo.Items (Id, Name, Description, Price, Fuel, Attack, Defense, ActionCooldownSeconds) VALUES (27, N'Diamond snowboard with the smoothest surface', null, 1000000, 0, 50, 0, 0);
INSERT INTO MijnDatabase.dbo.Items (Id, Name, Description, Price, Fuel, Attack, Defense, ActionCooldownSeconds) VALUES (28, N'Secondhand worn smelly snowboardgear', null, 20, 0, 0, 20, 0);
INSERT INTO MijnDatabase.dbo.Items (Id, Name, Description, Price, Fuel, Attack, Defense, ActionCooldownSeconds) VALUES (29, N'Snowboardgear from your cousin', null, 200, 0, 0, 150, 0);
INSERT INTO MijnDatabase.dbo.Items (Id, Name, Description, Price, Fuel, Attack, Defense, ActionCooldownSeconds) VALUES (30, N'Basic snowboardgear. And a helmet! ', null, 1000, 0, 0, 500, 0);
INSERT INTO MijnDatabase.dbo.Items (Id, Name, Description, Price, Fuel, Attack, Defense, ActionCooldownSeconds) VALUES (31, N'Cool snowboardgear. Looking fly', null, 10000, 0, 0, 2000, 0);
INSERT INTO MijnDatabase.dbo.Items (Id, Name, Description, Price, Fuel, Attack, Defense, ActionCooldownSeconds) VALUES (32, N'Burton snowboardsuit with temperature regulator', null, 10000, 0, 0, 2000, 0);
INSERT INTO MijnDatabase.dbo.Items (Id, Name, Description, Price, Fuel, Attack, Defense, ActionCooldownSeconds) VALUES (33, N'Coca cola', null, 8, 4, 0, 0, 50);
INSERT INTO MijnDatabase.dbo.Items (Id, Name, Description, Price, Fuel, Attack, Defense, ActionCooldownSeconds) VALUES (34, N'Basic snowboard', null, 50, 0, 50, 0, 0);
INSERT INTO MijnDatabase.dbo.Items (Id, Name, Description, Price, Fuel, Attack, Defense, ActionCooldownSeconds) VALUES (35, N'Energy Bar', null, 10, 5, 0, 0, 45);
INSERT INTO MijnDatabase.dbo.Items (Id, Name, Description, Price, Fuel, Attack, Defense, ActionCooldownSeconds) VALUES (36, N'Pizza', null, 500, 100, 0, 0, 25);
INSERT INTO MijnDatabase.dbo.Items (Id, Name, Description, Price, Fuel, Attack, Defense, ActionCooldownSeconds) VALUES (37, N'Gourmet', null, 500, 100, 0, 0, 25);
INSERT INTO MijnDatabase.dbo.Items (Id, Name, Description, Price, Fuel, Attack, Defense, ActionCooldownSeconds) VALUES (39, N'Developer Food', null, 1, 1000, 0, 0, 1);
INSERT INTO MijnDatabase.dbo.Items (Id, Name, Description, Price, Fuel, Attack, Defense, ActionCooldownSeconds) VALUES (40, N'Rubiks cube', N'You can solve it while waiting in the skilift.', 10, 0, 0, 0, 0);
INSERT INTO MijnDatabase.dbo.Items (Id, Name, Description, Price, Fuel, Attack, Defense, ActionCooldownSeconds) VALUES (41, N'Beer pong set', N'If you''re planning to have a party.', 21, 0, 0, 0, 0);
INSERT INTO MijnDatabase.dbo.Items (Id, Name, Description, Price, Fuel, Attack, Defense, ActionCooldownSeconds) VALUES (42, N'Cosy slippers in the shape of Homer Simpson', N'Makes you feel cosy in the chalet.', 30, 0, 0, 0, 0);
INSERT INTO MijnDatabase.dbo.Items (Id, Name, Description, Price, Fuel, Attack, Defense, ActionCooldownSeconds) VALUES (43, N'Big ass boombox', N'That''s loud.', 1000, 0, 0, 0, 0);
INSERT INTO MijnDatabase.dbo.Items (Id, Name, Description, Price, Fuel, Attack, Defense, ActionCooldownSeconds) VALUES (44, N'GOD MODE', N'This is almost how a GOD must feel.', 10000000, 1000000, 1000000, 1000000, 1);
INSERT INTO MijnDatabase.dbo.Items (Id, Name, Description, Price, Fuel, Attack, Defense, ActionCooldownSeconds) VALUES (45, N'Energy drinks - six pack', null, 300, 30, 0, 0, 30);
INSERT INTO MijnDatabase.dbo.Items (Id, Name, Description, Price, Fuel, Attack, Defense, ActionCooldownSeconds) VALUES (1025, N'All you can eat sushi', null, 3000, 500, 0, 0, 20);
INSERT INTO MijnDatabase.dbo.Items (Id, Name, Description, Price, Fuel, Attack, Defense, ActionCooldownSeconds) VALUES (2028, N'Gold Chain', N'You are officially dope.', 100, 0, 0, 0, 0);
INSERT INTO MijnDatabase.dbo.Items (Id, Name, Description, Price, Fuel, Attack, Defense, ActionCooldownSeconds) VALUES (3029, N'Snowboardgear made in China', null, 100, 0, 0, 50, 0);
INSERT INTO MijnDatabase.dbo.Items (Id, Name, Description, Price, Fuel, Attack, Defense, ActionCooldownSeconds) VALUES (3030, N'Carbon fibered board', null, 150, 0, 175, 0, 0);
INSERT INTO MijnDatabase.dbo.Items (Id, Name, Description, Price, Fuel, Attack, Defense, ActionCooldownSeconds) VALUES (3033, N'Flying Hirsch', null, 20, 10, 0, 0, 40);