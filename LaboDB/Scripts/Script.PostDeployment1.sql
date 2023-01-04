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
    ('Benjamin','Sterckx','ben@mail.be','Test1234=','0471/000000','super admin','1980-12-10', GETDATE(), 1, 1, '8484', 1),
    ('Tom','Tom','tom@mail.be','Test1234=','0471/000000','admin','1980-12-10',GETDATE(),1,2,'999',1),
    ('Jean','Jean','jean@mail.be','Test1234=','0471/000000','user','1980-12-10',GETDATE(),1,3,'666',1);
    

INSERT INTO Organisation([name],picture,createdAt,isActive,adress_Id) VALUES
    ('PADI','logo_padi.png',GETDATE(),1,4),
    ('SSI','logo_SSI.jpg',GETDATE(),1,5),
    ('LIFRAS','logo_LIFRAS.jpg',GETDATE(),1,6),
    ('FFESSM','logo_LIFRAS.jpg',GETDATE(),1,7);

INSERT INTO User_Organisation([user_Id],organisation_Id,[level],refNumber,createdAt) VALUES
    (1,1,'Instructor','848410',GETDATE()),   
    (2,2,'Divemaster','88',GETDATE()),   
    (3,3,'1 STAR','666',GETDATE());



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
    











    