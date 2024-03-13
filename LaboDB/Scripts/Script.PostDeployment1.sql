/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


INSERT INTO Country([name]) VALUES
    ('Belgique'),
    ('France'),
    ('Angleterre'),
    ('Etat-Unis'),
    ('Italy'),
    ('Luxembourg');

INSERT INTO City([name],postCode,country_Id) VALUES 
    ('Villers la ville',1495,1),
    ('Nivelles',1400,1),
    ('Wavre',1300,1),
    ('Californie',0000,4),
    ('Colorado',0000,4),
    ('Anderlecht',1070,1),
    ('Marseille',13284 ,2),
    ('Roseto',64026,5),
    ('Walhain',1457,1),
    ('Jodoigne',1370,1),
    ('Elouges',7370,1),
    ('Ekeren ',2030 ,1),
    ('Lultzhausen',9666,6),
    ('Floreffe',5150,1),
    ('Esneux',4130,1),
    ('Froidchapelle',6440,1),
    ('Lessines',7860,1),
    ('Sprimont',4140,1),
    ('Incourt',1315,1),
    ('Philippeville',5600,1),
    ('Cerfontaine',5630,1),
    ('Doische',5680,1);


INSERT INTO Adress(street,number,city_Id) VALUES
    ('rue du coin',5,1),
    ('rue de la bas',3,2),
    ('rue d ici',10,3),
    ('Rancho Santa Margarita',0,4),
    ('Fort Collins',0,5),
    ('Rue Jules Broeren',38,6),
    ('Quai de Rive Neuve',24,7),
    ('C/da Padune',11,8),
    ('Rue des Trois Fontaines',102,9),
    ('Rue des Carrières',1,10),
    ('Rue des Andrieux',174,11),
    ('Ekersedijk',1,12),
    ('Autour du lac',1,13),
    ('Rue Euriette',1,14),
    ('route Chera de la Gombe',2,15),
    ('Rue d oupiae',1,16),
    ('Rue de la Loge',80,17),
    ('Rue de Presseux',20,18),
    ('Rue de la Bruyère',1,19),
    ('Carrière de Rochefontaine',1,20),
    ('Rue du Traigneau',104,21),
    ('Route de Gimnée',1,22),
    ('Rue de Merlemont',26,20);



INSERT INTO Insurance([name],picture,createdAt,isActive,adress_Id) VALUES
    ('DAN','logo_DAN.png',GETDATE(),1,8);


INSERT INTO [User]( firstname,lastname, email, passwd, phone, [role], birthDate, createdAt, isActive, adress_Id,insuranceNumber, insurance_Id) VALUES
    ('Benjamin','Sterckx','ben@mail.be','$2a$10$EUxG8yCa2gznhPsVwv26gOCTqfMbJxyVOZ6w/ipaqIU1oBdv8OwLK','0471/000000','super admin','1980-12-10', GETDATE(), 1, 1, '8484', 1),
    ('Tom','Tom','tom@mail.be','$2a$10$EUxG8yCa2gznhPsVwv26gOCTqfMbJxyVOZ6w/ipaqIU1oBdv8OwLK','0471/000000','admin','1980-12-10',GETDATE(),1,2,'999',1),
    ('Jean','Jean','jean@mail.be','$2a$10$EUxG8yCa2gznhPsVwv26gOCTqfMbJxyVOZ6w/ipaqIU1oBdv8OwLK','0471/000000','user','1980-12-10',GETDATE(),1,3,'666',1),
    ('Paul','Paul','paul@mail.be','$2a$10$EUxG8yCa2gznhPsVwv26gOCTqfMbJxyVOZ6w/ipaqIU1oBdv8OwLK','0471/000000','user','1980-12-10',GETDATE(),1,3,'666',1);
    

INSERT INTO Organisation([name],picture,createdAt,isActive,adress_Id) VALUES
    ('PADI','logo_padi.png',GETDATE(),1,4),
    ('SSI','logo_SSI.jpg',GETDATE(),1,5),
    ('LIFRAS','logo_LIFRAS.jpg',GETDATE(),1,6),
    ('FFESSM','Logo_FFESSM.png',GETDATE(),1,7);



INSERT INTO User_Organisation([user_Id],organisation_Id,[level],refNumber,createdAt) VALUES
    (1,1,'Instructor','848410',GETDATE()),   
    (2,2,'Divemaster','88',GETDATE()),   
    (3,3,'1 STAR','666',GETDATE()),
    (4,4,'1 STAR','666',GETDATE());



INSERT INTO Diveplace([name],picture,map,createdAt,isActive,adress_Id) VALUES
    ('Trois Fontaines', '3fontaines.jpg','3fontaines.pdf', GETDATE(),1,9),
    ('Dongelberg', 'Dongelberg.jpg','dongelberg.pdf', GETDATE(),1,10),    
    ('Dour', 'Dour.jpg','dour.pdf', GETDATE(),1,11),
    ('Ekeren', 'Ekeren.jpg','ekeren.pdf', GETDATE(),1,12),
    ('Esch sur Sure', 'Esch_sur_Sure.jpg','esch.pdf', GETDATE(),1,13),
    ('Floreffe', 'Floreffe.jpg','floreffe.pdf', GETDATE(),1,14),
    ('La Gombe', 'Gombe.jpg','la_gombe.pdf', GETDATE(),1,15),
    ('La plate taille', 'La_plate_taille.jpg','plate_taille.pdf', GETDATE(),1,16),
    ('Lessine', 'Lessine.jpg','lessines.pdf', GETDATE(),1,17),
    ('Lillé', 'Lille.jpg','lille.pdf', GETDATE(),1,18),
    ('Opperbais', 'Opperbais.jpg','opprebais.pdf', GETDATE(),1,19),
    ('Rochefontaine', 'Rochefontaine.jpg','rochefontaine.pdf', GETDATE(),1,20),
    ('Villers le deux églises', 'V2E.jpg','villers.pdf', GETDATE(),1,21),
    ('Vodelee', 'Vodelee.jpg','vodelee.pdf', GETDATE(),1,22),
    ('Vodecee', 'Vodecee.jpg','vodecee.pdf', GETDATE(),1,23);
  

INSERT INTO [User_Diveplace]([user_Id],diveplace_Id,evaluation,createdAt) VALUES
    (1,1,8,GETDATE()),
    (1,2,6,GETDATE()),
    (1,3,7,GETDATE()),
    (1,4,9,GETDATE()),
    (1,5,7,GETDATE()),
    (1,6,9,GETDATE()),
    (1,7,6,GETDATE()),
    (1,8,6,GETDATE()),
    (1,9,4,GETDATE()),
    (1,10,6,GETDATE()),
    (1,11,7,GETDATE()),
    (1,12,9,GETDATE()),
    (1,13,9,GETDATE()),
    (1,14,9,GETDATE()),
    (1,15,9,GETDATE()),

    (2,1,5,GETDATE()),
    (2,2,6,GETDATE()),
    (2,3,7,GETDATE()),
    (2,4,7,GETDATE()),
    (2,5,4,GETDATE()),
    (2,6,6,GETDATE()),
    (2,7,9,GETDATE()),
    (2,8,2,GETDATE()),
    (2,9,9,GETDATE()),
    (2,10,5,GETDATE()),
    (2,11,9,GETDATE()),
    (2,12,9,GETDATE()),
    (2,13,9,GETDATE()),
    (2,14,9,GETDATE()),
    (2,15,9,GETDATE());


INSERT INTO [Training]([name],prerequis,picture,isSpeciality, createdAt, isActive, organisation_Id) VALUES
  ('Open Water Diver','rien','logo_padi.png',0,GETDATE(),1,1),
    ('Advenced Open Water Diver','rien','logo_padi.png',0,GETDATE(),1,1),
    ('Rescue Diver','rien','logo_padi.png',0,GETDATE(),1,1),
    ('Divemaster','rien','logo_padi.png',0,GETDATE(),1,1),

    ('Open Water Diver','rien','logo_SSI.jpg',0,GETDATE(),1,2),
    ('Advenced Open Water Diver','rien','logo_SSI.jpg',0,GETDATE(),1,2),
    ('Rescue Diver','rien','logo_SSI.jpg',0,GETDATE(),1,2),
    ('Divemaster','rien','logo_SSI.jpg',0,GETDATE(),1,2),

    ('1*','rien','logo_LIFRAS.jpg',0,GETDATE(),1,3),
    ('2**','rien','logo_LIFRAS.jpg',0,GETDATE(),1,3),
    ('3**','rien','logo_LIFRAS.jpg',0,GETDATE(),1,3),

    ('1*','rien','Logo_FFESSM.png',0,GETDATE(),1,4),
    ('2**','rien','Logo_FFESSM.png',0,GETDATE(),1,4),
    ('3**','rien','Logo_FFESSM.png',0,GETDATE(),1,4);
   

INSERT INTO Club([Name],createdAt, isActive,adress_Id,creator_Id,organisation_id)VALUES
    ('EYD',GETDATE(),1,1,1,1)

INSERT INTO [User_Club](user_Id,club_Id,createdAt)VALUES
    (1,1,GETDATE()),
    (2,1,GETDATE()),
    (3,1,GETDATE()),
    (4,1,GETDATE());

INSERT INTO [Event]([name], startDate, endDate, createdAt, isActive, diveplace_Id,creator_Id, training_Id ,club_Id) VALUES
    ('Loisir','2023-01-01','2023-01-02', GETDATE(),1,1,1,null,null),
    ('Formation','2024-05-01','2024-05-02', GETDATE(),1,2,2,1,1),
    ('Loisir','2024-05-01','2024-05-02', GETDATE(),1,3,1,2,1),
    ('Loisir','2024-06-01','2024-06-02', GETDATE(),1,4,2,3,1),
    ('Loisir','2024-07-10','2024-07-12', GETDATE(),1,5,1,4,1),
    ('Loisir','2024-06-01','2024-08-02', GETDATE(),1,6,2,5,1),
    ('Loisir','2024-12-01','2024-12-02', GETDATE(),1,7,1,null,null),
    ('Loisir','2024-05-08','2024-05-09', GETDATE(),1,8,2,8,1),
    ('Loisir','2024-05-17','2024-05-25', GETDATE(),1,9,2,9,1),
    ('Loisir','2024-10-10','2024-10-10', GETDATE(),1,10,1,10,1),
    ('Loisir','2024-11-01','2024-11-02', GETDATE(),1,11,2,null,null),
    ('Loisir','2024-08-15','2024-08-15', GETDATE(),1,12,1,11,1),
    ('Loisir','2024-08-18','2024-08-19', GETDATE(),1,13,2,12,1);

INSERT INTO Divelog(diveType,[description],duration,maxDeep, airTemperature, waterTemperature,diveDate, createdAt,isActive,[user_Id],event_Id) VALUES
    ('formation','chouette',45,15,15,15,'2022-01-01',GETDATE(),1,1,null),
    ('formation','chouette',55,20,16,15,'2022-01-02',GETDATE(),1,2,2),
    ('formation','chouette',50,25,18,16,'2022-01-03',GETDATE(),1,3,1),
    ('formation','chouette',52,18,15,16,'2022-01-04',GETDATE(),1,1,3),
    ('formation','chouette',47,30,20,16,'2022-01-05',GETDATE(),1,2,4),
    ('formation','chouette',59,35,21,16,'2022-01-06',GETDATE(),1,3,5),
    ('formation','chouette',62,16,15,16,'2022-01-07',GETDATE(),1,1,1),
    ('formation','chouette',45,18,14,16,'2022-01-08',GETDATE(),1,2,6),
    ('formation','chouette',46,20,15,17,'2022-01-09',GETDATE(),1,1,1),
    ('formation','chouette',42,14,15,17,'2022-01-10',GETDATE(),1,3,5);


INSERT INTO [Participe](user_Id,event_Id,createdAt)VALUES
    (1,1,GETDATE()),
    (1,2,GETDATE()),
    (1,3,GETDATE()),
    (1,4,GETDATE()),
    (2,1,GETDATE()),
    (2,2,GETDATE()),
    (2,6,GETDATE()),
    (3,1,GETDATE()),
    (3,4,GETDATE()),
    (3,10,GETDATE()),
    (3,9,GETDATE());


INSERT INTO Invite(inviter_Id,invited_Id,event_Id,createdAt)VALUES
    (1,2,1,GETDATE()),
    (1,3,1,GETDATE()),
    (1,2,2,GETDATE()),
    (2,1,3,GETDATE()),
    (2,3,3,GETDATE()),
    (2,1,10,GETDATE()),
    (1,3,6,GETDATE()),
    (1,2,7,GETDATE()),
    (1,4,10,GETDATE()),
    (3,1,5,GETDATE()),
    (3,2,5,GETDATE()),
    (3,3,5,GETDATE()),
    (3,2,7,GETDATE()),
    (3,2,8,GETDATE());
   

INSERT INTO [Like](liker_Id,liked_Id,createdAt)VALUES
   (1,2,GETDATE()),   
   (1,3,GETDATE()),   
   (1,4,GETDATE()),   
   (2,1,GETDATE()),
   (2,3,GETDATE()),
   (2,4,GETDATE()),
   (3,1,GETDATE()),
   (3,2,GETDATE()),
   (4,2,GETDATE()),
   (4,3,GETDATE());