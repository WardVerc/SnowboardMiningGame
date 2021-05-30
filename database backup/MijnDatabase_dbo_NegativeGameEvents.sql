create table NegativeGameEvents
(
    Id                            int identity
        constraint PK_NegativeGameEvents
            primary key,
    Name                          nvarchar(max),
    Description                   nvarchar(max),
    DefenseWithGearDescription    nvarchar(max),
    DefenseWithoutGearDescription nvarchar(max),
    DefenseLoss                   int not null,
    Probability                   int not null
)
go

INSERT INTO MijnDatabase.dbo.NegativeGameEvents (Id, Name, Description, DefenseWithGearDescription, DefenseWithoutGearDescription, DefenseLoss, Probability) VALUES (5, N'Ice spot', N'As you are boarding, you hear noise coming from under your board and you start to slip', N'Your gear prevents you from falling and you keep sliding. You continue on the snow', N'You lose your balance and you fell on your butt on the hard ice. That hurt!', 2, 100);
INSERT INTO MijnDatabase.dbo.NegativeGameEvents (Id, Name, Description, DefenseWithGearDescription, DefenseWithoutGearDescription, DefenseLoss, Probability) VALUES (6, N'Skilift exit', N'As you are coming to the exit of the skilift, you didn''t expect the lift to go this fast and the person next to you is swinging his arms', N'With your Matrix-like moves (and your gear), you keep your balance while the others of the skilift fall down', N'The person next to you hits you in the face by accident and you all fall. People are mad because you guys are blocking the exit', 3, 50);
INSERT INTO MijnDatabase.dbo.NegativeGameEvents (Id, Name, Description, DefenseWithGearDescription, DefenseWithoutGearDescription, DefenseLoss, Probability) VALUES (7, N'Bottle leak', N'As you are sitting on the skilift, you feel your backpack is getting wet because your bottle of water is leaking', N'Your snowboard gear is waterproof and you just feel a bit cold', N'Your clothes are frozen to your back. You pull your clothes from your skin. Ouch!', 2, 100);
INSERT INTO MijnDatabase.dbo.NegativeGameEvents (Id, Name, Description, DefenseWithGearDescription, DefenseWithoutGearDescription, DefenseLoss, Probability) VALUES (8, N'Failed trick attempt', N'As you are approaching a big jump, you legs start to wiggle and you  can''t avoid the jump anymore', N'You land on your back but the backplate of your gear caught the fall. You walk away like it was nothing', N'You land on your back. That looked painful', 3, 50);
INSERT INTO MijnDatabase.dbo.NegativeGameEvents (Id, Name, Description, DefenseWithGearDescription, DefenseWithoutGearDescription, DefenseLoss, Probability) VALUES (1005, N'Angry Yeti', N'Yeti appears and blocks the way. You can''t escape ...', N'Luckily your gear protects you from his claws.', N'The Yeti scratches your back, you can barely escape just in time.', 2, 30);