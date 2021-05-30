create table PositiveGameEvents
(
    Id          int identity
        constraint PK_PositiveGameEvents
            primary key,
    Name        nvarchar(max),
    Description nvarchar(max),
    Money       int not null,
    Experience  int not null,
    Probability int not null
)
go

INSERT INTO MijnDatabase.dbo.PositiveGameEvents (Id, Name, Description, Money, Experience, Probability) VALUES (34, N'The biggest jump again, but now you don''t think, you just do. And you landed the dopest trick while everybody was watching from the apres ski. You''re a legend now and everybody loves you for eternity.', null, 30000, 1500, 10);
INSERT INTO MijnDatabase.dbo.PositiveGameEvents (Id, Name, Description, Money, Experience, Probability) VALUES (35, N'The key to a mansion in the middle of the slopes, with a pool and sauna. Aww yeeea', null, 20000, 1000, 10);
INSERT INTO MijnDatabase.dbo.PositiveGameEvents (Id, Name, Description, Money, Experience, Probability) VALUES (36, N'The snowboard of the legend, Shaun White', null, 3000, 400, 30);
INSERT INTO MijnDatabase.dbo.PositiveGameEvents (Id, Name, Description, Money, Experience, Probability) VALUES (37, N'The biggest jump you ever saw', N'You chickend out and boarded next to it, watching actual cool snowboarders do sick tricks on the jump. Your eyes start to water up and you ride home.', 0, 0, 500);
INSERT INTO MijnDatabase.dbo.PositiveGameEvents (Id, Name, Description, Money, Experience, Probability) VALUES (38, N'A lot of mist, no boarding this time, but you play boardgames inside the chalet', null, 0, 0, 1000);
INSERT INTO MijnDatabase.dbo.PositiveGameEvents (Id, Name, Description, Money, Experience, Probability) VALUES (39, N'A regular backpack', N'You hold it to the light and seek in it to find the name of the owner, but it remains empty. You give it to your friend as a gift, the bag was ugly anyway.', 0, 0, 1000);
INSERT INTO MijnDatabase.dbo.PositiveGameEvents (Id, Name, Description, Money, Experience, Probability) VALUES (40, N'Snow', N'Woohoo! Snow!', 0, 0, 1000);
INSERT INTO MijnDatabase.dbo.PositiveGameEvents (Id, Name, Description, Money, Experience, Probability) VALUES (42, N'A colorful hat that is not your size', null, 1, 1, 300);
INSERT INTO MijnDatabase.dbo.PositiveGameEvents (Id, Name, Description, Money, Experience, Probability) VALUES (43, N'Nobody, you''re the first one on the slope. Going down the slope clearing your head', null, 1, 1, 300);
INSERT INTO MijnDatabase.dbo.PositiveGameEvents (Id, Name, Description, Money, Experience, Probability) VALUES (44, N'A fresh prepared slope. So smooth', null, 1, 1, 300);
INSERT INTO MijnDatabase.dbo.PositiveGameEvents (Id, Name, Description, Money, Experience, Probability) VALUES (45, N'An epic trick your friend landed after 42 tries and you were filming. The clip is awesome', null, 5, 3, 1000);
INSERT INTO MijnDatabase.dbo.PositiveGameEvents (Id, Name, Description, Money, Experience, Probability) VALUES (46, N'A flat part of the slope. You stand on the back of your board on one leg. Balance increases', null, 10, 5, 800);
INSERT INTO MijnDatabase.dbo.PositiveGameEvents (Id, Name, Description, Money, Experience, Probability) VALUES (47, N'One snowboard boot. Where''s the other one?', null, 10, 5, 800);
INSERT INTO MijnDatabase.dbo.PositiveGameEvents (Id, Name, Description, Money, Experience, Probability) VALUES (48, N'10 euros on the floor of the bathroom at the apres ski', null, 10, 5, 800);
INSERT INTO MijnDatabase.dbo.PositiveGameEvents (Id, Name, Description, Money, Experience, Probability) VALUES (49, N'A swiss knife. Looks new', null, 12, 6, 700);
INSERT INTO MijnDatabase.dbo.PositiveGameEvents (Id, Name, Description, Money, Experience, Probability) VALUES (50, N'A brand new Go Pro camera that is not released yet', null, 2000, 350, 30);
INSERT INTO MijnDatabase.dbo.PositiveGameEvents (Id, Name, Description, Money, Experience, Probability) VALUES (51, N'Sunglasses that are too small for your head', null, 20, 8, 650);
INSERT INTO MijnDatabase.dbo.PositiveGameEvents (Id, Name, Description, Money, Experience, Probability) VALUES (52, N'A friend who bets you couldn''t do a backflip. But you did. Showoff', null, 50, 13, 400);
INSERT INTO MijnDatabase.dbo.PositiveGameEvents (Id, Name, Description, Money, Experience, Probability) VALUES (53, N'A long rail. You grind it halfway until you lost your balance. Only 1 bruise, nice', null, 60, 15, 400);
INSERT INTO MijnDatabase.dbo.PositiveGameEvents (Id, Name, Description, Money, Experience, Probability) VALUES (54, N'A small jump. You do a frontflip off of it. Easy', null, 100, 40, 350);
INSERT INTO MijnDatabase.dbo.PositiveGameEvents (Id, Name, Description, Money, Experience, Probability) VALUES (55, N'A halfpipe. You go for it and do pretty okay all the way, no bruises this time', null, 140, 50, 300);
INSERT INTO MijnDatabase.dbo.PositiveGameEvents (Id, Name, Description, Money, Experience, Probability) VALUES (56, N'A badass coat. You look fly now', null, 160, 80, 300);
INSERT INTO MijnDatabase.dbo.PositiveGameEvents (Id, Name, Description, Money, Experience, Probability) VALUES (57, N'A trumpet. Not sure how it got here', null, 160, 80, 300);
INSERT INTO MijnDatabase.dbo.PositiveGameEvents (Id, Name, Description, Money, Experience, Probability) VALUES (58, N'A bottle of champagne', null, 180, 80, 300);
INSERT INTO MijnDatabase.dbo.PositiveGameEvents (Id, Name, Description, Money, Experience, Probability) VALUES (59, N'A really cool snowboard with stickers and stuff', null, 300, 100, 110);
INSERT INTO MijnDatabase.dbo.PositiveGameEvents (Id, Name, Description, Money, Experience, Probability) VALUES (60, N'The other snowboard boot!', null, 300, 100, 80);
INSERT INTO MijnDatabase.dbo.PositiveGameEvents (Id, Name, Description, Money, Experience, Probability) VALUES (61, N'A Charizard Pokémon card in good condition', null, 400, 150, 200);
INSERT INTO MijnDatabase.dbo.PositiveGameEvents (Id, Name, Description, Money, Experience, Probability) VALUES (62, N'Your future girlfriend/boyfriend', null, 500, 150, 150);
INSERT INTO MijnDatabase.dbo.PositiveGameEvents (Id, Name, Description, Money, Experience, Probability) VALUES (63, N'Seppe Smits giving you a high five after you did a 720 Triple McTwist', null, 1000, 200, 100);
INSERT INTO MijnDatabase.dbo.PositiveGameEvents (Id, Name, Description, Money, Experience, Probability) VALUES (64, N'The elixir of snowboarding superpowers', null, 60000, 1500, 5);
INSERT INTO MijnDatabase.dbo.PositiveGameEvents (Id, Name, Description, Money, Experience, Probability) VALUES (65, N'Warm ski gloves. Too bad they''re not your size, you sell them', null, 30, 10, 500);
INSERT INTO MijnDatabase.dbo.PositiveGameEvents (Id, Name, Description, Money, Experience, Probability) VALUES (66, N'An average slope on an average day', null, 0, 0, 1000);
INSERT INTO MijnDatabase.dbo.PositiveGameEvents (Id, Name, Description, Money, Experience, Probability) VALUES (2034, N'A friendly Yeti, he''s scary and hairy', N'You go even faster', 0, 50, 4000);