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



INSERT INTO [User]( firstname,lastname, email, passwd, [role], birthDate, createdAt, isActive, adress_Id, isLevelValid, medicalDateValidation, insuranceDateValidation) VALUES
    ('Benjamin','Sterckx','ben@mail.be','$2a$10$EUxG8yCa2gznhPsVwv26gOCTqfMbJxyVOZ6w/ipaqIU1oBdv8OwLK','super admin','1980-12-10', GETDATE(), 1, 1,1,'2024-12-10','2024-12-10'),
    ('Tom','Tom','tom@mail.be','$2a$10$EUxG8yCa2gznhPsVwv26gOCTqfMbJxyVOZ6w/ipaqIU1oBdv8OwLK','admin','1980-12-10',GETDATE(),1,2,1,'2024-10-10','2024-11-10'),
    ('Jean','Jean','jean@mail.be','$2a$10$EUxG8yCa2gznhPsVwv26gOCTqfMbJxyVOZ6w/ipaqIU1oBdv8OwLK','user','1980-12-10',GETDATE(),1,3,1,'2024-04-10','2023-02-10'),
    ('Paul','Paul','paul@mail.be','$2a$10$EUxG8yCa2gznhPsVwv26gOCTqfMbJxyVOZ6w/ipaqIU1oBdv8OwLK','user','1980-12-10',GETDATE(),1,3,1,'2023-03-10','2023-05-10');
    

INSERT INTO Organisation([name],createdAt,isActive,adress_Id) VALUES
    ('PADI',GETDATE(),1,4),
    ('SSI',GETDATE(),1,5),
    ('LIFRAS',GETDATE(),1,6),
    ('FFESSM',GETDATE(),1,7);

INSERT INTO [Training]([name], prerequis,picture,isSpeciality, createdAt, isActive, organisation_Id ,[description]) VALUES
  ('Open Water Diver','rien','logo_padi.png',0,GETDATE(),1,1,'L Open Water Diver PADI est le premier niveau de certification de plongée sous-marine. Un PADI Instructor hautement qualifié vous apprendra à plonger dans un environnement pédagogique détendu et sécurisant. À la fin du cours, vous aurez les techniques et les connaissances nécessaires pour plonger près de chez vous ou à l étranger et vous serez un ambassadeur du monde sous-marin.'),
    ('Advanced Open Water Diver','rien','logo_padi.png',0,GETDATE(),1,1,'Le cours Advanced Open Water Diver, c est tout ce qu il vous faut pour améliorer vos compétences. Vous pourrez pratiquer l orientation sous-marine et la maîtrise de la flottabilité, essayer la plongée profonde et faire trois plongées de spécialité de votre choix (c est comme un plateau d échantillons de plongées de spécialité). Pour chaque plongée de spécialité que vous complétez, vous pouvez obtenir un crédit vers les certifications PADI'),
    ('Rescue Diver','rien','logo_padi.png',0,GETDATE(),1,1,'Le cours PADI Rescue Diver changera votre façon de plonger – de la meilleure façon possible. Apprenez à identifier et à résoudre les problèmes mineurs avant qu ils ne deviennent de gros problèmes, gagnez en confiance et amusez-vous sérieusement en cours de route.'),
    ('Divemaster','rien','logo_padi.png',0,GETDATE(),1,1,'Apprenez à diriger des plongées excursions, à être assistant pendant des cours de plongée et à inciter d autres personnes à se préoccuper de l océan. Perfectionnez vos techniques et devenez le plongeur que tout le monde admire. '),
    ('Instructor','rien','logo_padi.png',0,GETDATE(),1,1,'Proposer des formations PADI du bapteme a Divemaster '),

    ('Open Water Diver','rien','logo_SSI.jpg',0,GETDATE(),1,2,'Ce programme de certification reconnu mondialement est le meilleur moyen de commencer vos aventures de toute une vie en tant que plongeur certifié. Une formation personnalisée est combinée à des séances de pratique dans l’eau pour vous permettre d’acquérir les compétences et l’expérience nécessaires pour être vraiment à l’aise sous l’eau. Vous obtiendrez la certification Open Water Diver SSI.'),
    ('Advenced Open Water Diver','rien','logo_SSI.jpg',0,GETDATE(),1,2,'Au cours du programme Advanced Adventurer, vous testerez 5 spécialités différentes. Vous effectuerez une plongée de formation en milieu naturel par spécialité après un briefing complet avec votre instructeur SSI.'),
    ('Diver Stress and Rescue','rien','logo_SSI.jpg',0,GETDATE(),1,2,'Le programme de spécialité Diver Stress and Rescue SSI vous enseigne les compétences dont vous avez besoin pour vous protéger et protéger les autres plongeurs. Vous apprendrez à identifier le stress, à prévenir les accidents et vous recevrez des techniques pratiques pour effectuer des sauvetages et fournir des soins d’urgence. Grâce à une combinaison de séances pratique en piscine et en milieu naturel, vous deviendrez bien préparé et confiant dans la gestion des situations d’urgence et de sauvetage. À l’issue de ce cours, vous obtiendrez la certification de spécialité Diver Stress and Rescue SSI.'),
    ('Dive Guide','rien','logo_SSI.jpg',0,GETDATE(),1,2,'Le programme Dive Guide est la première étape d’un projet passionnant. Apprenez à guider en toute sécurité des plongeurs certifiés dans divers environnements et conditions. En donnant des briefings de plongée, en effectuant des évaluations de sites et en dirigeant des plongées, vous deviendrez en un rien de temps un guide de plongée confiant. Commencez votre carrière de plongeur en travaillant comme Dive Guide Professionnel ou poursuivez les qualifications pour devenir Divemaster.'),
     ('Instructor','rien','logo_SSI.jpg',0,GETDATE(),1,2,'Proposer des formations SSI du bapteme a Divemaster '),

    ('1*','rien','logo_LIFRAS.jpg',0,GETDATE(),1,3,'Permet d acquérir les bases de la plongée sous-marine. Les plongeurs apprennent les techniques de base de la plongée, y compris l utilisation du matériel, la maîtrise de la flottabilité, la communication sous-marine, et les règles de sécurité. Les plongées sont généralement limitées à une profondeur maximale de 20 mètres, sous la supervision d un moniteur qualifié.'),
    ('2*','rien','logo_LIFRAS.jpg',0,GETDATE(),1,3,'Correspond à une étape intermédiaire de progression dans la pratique de la plongée sous-marine. Les plongeurs approfondissent leurs compétences techniques et leur connaissance de l environnement sous-marin. Ils apprennent à planifier et à réaliser des plongées en autonomie, tout en respectant les règles de sécurité. Les plongées peuvent être effectuées jusqu à une profondeur maximale de 40 mètres, sous la supervision d un moniteur qualifié.'),
    ('3*','rien','logo_LIFRAS.jpg',0,GETDATE(),1,3,'Représente le niveau avancé de la formation en plongée LIFRAS. Les plongeurs acquièrent une expertise plus approfondie dans différents aspects de la plongée, y compris la navigation sous-marine, la gestion des situations d urgence, et la plongée en conditions plus techniques. Ils sont formés à la supervision de plongeurs moins expérimentés et à la gestion de groupes en plongée. Les plongeurs peuvent réaliser des plongées jusqu à une profondeur maximale de 60 mètres, sous réserve de détenir les qualifications nécessaires et d être accompagnés d un moniteur qualifié si nécessaire.'),
     ('Instructor','rien','logo_LIFRAS.jpg',0,GETDATE(),1,3,'Proposer des formations LIFRAS du bapteme a 3* '),

    ('1*','rien','Logo_FFESSM.png',0,GETDATE(),1,4,'Permet d acquérir les bases de la plongée sous-marine. Les plongeurs apprennent les techniques de base de la plongée, y compris l utilisation du matériel, la maîtrise de la flottabilité, la communication sous-marine, et les règles de sécurité. Les plongées sont généralement limitées à une profondeur maximale de 20 mètres, sous la supervision d un moniteur qualifié.'),
    ('2*','rien','Logo_FFESSM.png',0,GETDATE(),1,4,'Correspond à une étape intermédiaire de progression dans la pratique de la plongée sous-marine. Les plongeurs approfondissent leurs compétences techniques et leur connaissance de l environnement sous-marin. Ils apprennent à planifier et à réaliser des plongées en autonomie, tout en respectant les règles de sécurité. Les plongées peuvent être effectuées jusqu à une profondeur maximale de 40 mètres, sous la supervision d un moniteur qualifié.'),
    ('3*','rien','Logo_FFESSM.png',0,GETDATE(),1,4,'Représente le niveau avancé de la formation en plongée FFESSM. Les plongeurs acquièrent une expertise plus approfondie dans différents aspects de la plongée, y compris la navigation sous-marine, la gestion des situations d urgence, et la plongée en conditions plus techniques. Ils sont formés à la supervision de plongeurs moins expérimentés et à la gestion de groupes en plongée. Les plongeurs peuvent réaliser des plongées jusqu à une profondeur maximale de 60 mètres, sous réserve de détenir les qualifications nécessaires et d être accompagnés d un moniteur qualifié si nécessaire.'),
    ('Instructor','rien','Logo_FFESSM.png',0,GETDATE(),1,4,'Proposer des formations FFESSM du bapteme a 3* ');

INSERT INTO [User_Training]([user_Id],training_Id,refNumber,createdAt,isMostLevel) VALUES
    (1,5,'848410',GETDATE(),1),   
    (1,1,'848410',GETDATE(),0),   
    (1,2,'848410',GETDATE(),0),   
    (1,3,'848410',GETDATE(),0),   
    (1,4,'848410',GETDATE(),0),   
    (2,2,'88',GETDATE(),1),   
    (3,3,'666',GETDATE(),1),
    (4,4,'666',GETDATE(),1);

    --'3fontaines.jpg','3fontaines.pdf',
    --'Dongelberg.jpg','dongelberg.pdf',
    --'Dour.jpg','dour.pdf',
    --'Ekeren.jpg','ekeren.pdf',
    --'Esch_sur_Sure.jpg','esch.pdf',
    --'Floreffe.jpg','floreffe.pdf',
    --'Gombe.jpg','la_gombe.pdf',
    --'La_plate_taille.jpg','plate_taille.pdf',
    --'Lessine.jpg','lessines.pdf',
    --'Lille.jpg','lille.pdf',
    --'Opperbais.jpg','opprebais.pdf',
    --'Rochefontaine.jpg','rochefontaine.pdf',
    --'V2E.jpg','villers.pdf',
    --'Vodelee.jpg','vodelee.pdf',
    --'Vodecee.jpg','vodecee.pdf',
INSERT INTO Diveplace(creator_Id,[name],createdAt,isActive,adress_Id, gps, maxDepp, price, compressor, restoration,[url],[description]) VALUES
    (1,'Trois Fontaines',GETDATE(),1,9,'50.635856, 4.646673',18,6,0,1,'https://timberdiving.be/reservations/','Ancienne carrière de quartzite réhabilitée pour la plongée.'),
    (2,'Dongelberg',  GETDATE(),1,10,'50°4145''N  04°4910''E',40,4,1,1,'https://cpdongelberg.be/','Dongelberg est une ancienne carrière de quartzites ouverte aux plongeurs depuis 1980. Située à proximité de Liège, elle est la propriété de VMW (Vlaamse Watermaatschappij) et de la Société Wallonne des Eaux. Elle offre une série de plateaux étagés jusqu à 40 m de profondeur. De quoi satisfaire l ensemble des plongeurs...'),    
    (3,'Dour',  GETDATE(),1,11,'50°25′ 02″ N 003°45′ 50″ E',22,4,1,1,'https://www.hainosaurusboussudour.be/','Ancien site ayant servi pour la fabrication de chaux industrielle, située en région wallonne, dans la zone frontalière non loin de Valenciennes, la carrière de Dour possède un magnifique plan d’eau d’environ 2 ha et une profondeur maximale variant de 18 à 22m (selon la saison). D’aspect bleu turquoise, elle est composée de plusieurs plateaux et pentes douces permettent de réaliser tout type de plongée, de la plongée baptême à la plongée d’exploration.'),
    (4,'Ekeren',  GETDATE(),1,12,'51.1700 4.2320',21,3,1,0,'https://www.avos.be/site/index.php','Egalement connu sous le nom de "Puits d Ekeren" ou "Etang de Muisbroek", le lac d Ekeren est situé immédiatement au nord d Anvers,  dans un très beau parc boisé d’une superficie de 12 hectares. C est pour cela que, pour y plonger, il est nécessaire d obtenir un permis auprès la structure gestionnaire pour un prix variant de 3€ (à la journée) à 20€ (valable 3 ans). La carrière possède pas mal d’herbiers, plusieurs statues, un tombant vers les 20m et beaucoup de vie aquatique.'),
    --('Esch sur Sure',  GETDATE(),1,13),
    (1,'Floreffe',  GETDATE(),1,14,'50°2530''N  04°4427''E',20,4,0,0,'https://www.fpp-plongee.be/','La carrière de Floreffe est une jeune carrière inondée. En effet, l’exploitation axée sur l’extraction de la dolomie (CaMg(CO3)2) afin d’approvisionner principalement les verreries, n’a débuté qu’à la fin des années 70. En 1984, le creusement atteint la nappe phréatique qui inonde le site assez rapidement et naturellement toute exploitation cesse par suite de l’inondation. Elle fait 280 mètres de long sur 80 mètres de large, soit un peu plus de 2 hectares de superficie. La profondeur maximum est de 20 mètres en fonction des variations de la nappe phréatique et la profondeur moyenne est de 15 mètres. les parois sont pratiquement verticales jusqu’au fond. L’endroit de mise à l’eau est en pente douce, ce qui facilite la tâche pour les personnes à mobilité réduite et pour les plongées baptêmes et enfants.'),
    (2,'La Gombe',  GETDATE(),1,15,'50.509084, 5.566270',30,8,1,1,'https://clas.be/carriere-de-la-gombe/','Ancienne carrière désaffectée de marbre gris, la Gombe offre un magnifique plan d eau claire d une profondeur de – 31 mètres. Dans ces eaux, une faune et une flore variées se laissent admirer pour le plus grand plaisir des plongeurs. L inauguration officielle du centre de plongée à eu lieu le 12 février 1977 en présence de Monsieur J-P.Graffé sénateur à l époque, ainsi que de nombreuses autorités politique et du monde de la plongée. La Gombe reçoit des plongeurs de toutes les régions de Belgique mais aussi de l étranger qui s y retrouvent pour pratiquer la plongée, réaliser des exercices ou simplement pour le plaisir et prendre le verre de l amitié dans un club house accueillant.'),
    (3,'La plate taille',  GETDATE(),1,16,'N50°10"60'' E4°23"16''',35,5,1,1,'https://www.cpbeh.net/','La Plate Taille est le lac le plus étendu d un complexe de cinq lacs artificiels (Plate Taille, Ry Jaune, Falemprise, Eau d Heure, Féronval) établis sur le cours de la rivière de l Eau d Heure, affuent de la Sambre. Le site offre une profondeur pouvant atteindre 35 m. Le niveau est cependant assez variable et les profondeurs indiquées sur le plan ci-dessous peuvent varier sensiblement.'),
    (4,'Lessine',  GETDATE(),1,17,'50.4217 3.5059',40,5,1,0,'','Lessines est une ancienne carrière de porphyre, une roche souvent utilisée pour les remblais d’autoroutes ou de voies de chemin de fer. Elle est située en Belgique, à mi-chemin entre Lille et Bruxelles. Elle offre une profondeur maximale de 54 m et généralement une bonne visibilité sur les 30 premiers mètres. Elle est équipée de vestiaires chauffés (particulièrement appréciables en hiver). Le ponton de mise à l eau est accessible par un (très) long escalier. Il est également desservi par un chariot treuillé qui permet d y descendre (et de remonter) tout le matériel de plongée.'),
    (1,'Lillé',  GETDATE(),1,18,'50.501909, 5.649964',30,3,1,1,'https://www.cip-lille.com/','D une profondeur variant entre 24 et 30 mètres selon le niveau de l eau, la carrière offre de nombreuses possibilités de plongée. L importante infrastructure et les nombreux services mis à disposition permettent l organisation de sorties plongées confortables toute l année. En outre, l accueil chaleureux, le cadre verdoyant et l excellente carte proposée par le restaurant garantissent des journées de détente et de loisirs dans une ambiance détendue et amicale..'),
    (3,'Opperbais',  GETDATE(),1,19,'50.686370, 4.805304',27,5,0,0,'https://www.cpno.be/www/index.php','Ancienne carrière de sable et de calcaire, cessation des activités en 1975. Profondeur maximale entre 27 & 30m. Accès limité aux membres du CPNO (Club Plongée Nature Opprebais). Réservation obligatoire par téléphone ou en ligne via le site.'),
    (2,'Rochefontaine',  GETDATE(),1,20,'N50°11"59"" E4°38"31''',52,8,1,1,'https://www.rochefontaine.be/','La Rochefontaine est une ancienne carrière de marbre rouge, aujourd hui noyée. Elle est située en Belgique, à l est de Philippeville. Elle offre une profondeur maximale de 53 m et possède la particularité d être surplombée d une grue derrick.'),
    (4,'Villers le deux églises',  GETDATE(),1,21,'N50°11"06"" E4°29"50''',28,8,1,1,'https://carrierev2e.be/','La profondeur maximale de la carrière est de 28 mètres. Sa faune est, entre autre, composée d’éponges, d’hydres d’eau douce, de mollusques, de perches, koïs, carpes et d’esturgeons. Il reste des vestiges submergés de l’exploitation de la carrière, tels que des citernes, des treuils, des wagons d’excavation et leurs rails ainsi que des poulies. D’autres objets ont été rajoutés par la suite pour l’amusement des plongeurs.'),
    (1,'Vodelee',  GETDATE(),1,22,'N50°0954'' E4°4340''',40,8,1,1,'https://www.royalcas.be/carriere-de-vodelee/','Cette carrière de marbre rouge couvre une superficie d’ un hectare et demi et affiche une profondeur de 40 mètres maximum. De nombreux plateaux à différents niveaux permettent une plongée sympathique det distrayante  pour tous les niveaux de plongeurs. Beaucoup de choses à voir et à faire : Passage dans un silo ou dans des anfractuosités naturelles, découverte d’épave de voilier, d’un char, rencontre avec la faune présente dans la carrière ; Carpes, Esturgeons, Silure, Brochets, Spatula, Anguilles , Ecrevisses. Des vestiaires sont à votre disposition ainsi qu’une station de gonflage. Un clubhouse offrant un large choix de boissons et de petite restauration vous réconfortera après votre plongée.'),
    (1,'Vodecee',  GETDATE(),1,23,'50.194985, 4.573861',31,8,1,1,'https://croisette.be/','Située dans un cadre agréable, la carrière de la Croisette est un centre de plongée profonde doté de toutes les facilités permettant des plongées confortables et en toute sécurité.Ancienne carrière de marbre rouge d’une profondeur max de 31m. Une partie de la carrière est protégée par un filet afin de permettre la reproduction de la flore, on y retrouvera notamment des nénufars, carpes et perches de taille importante. Vers 27 mètres se trouvent plusieurs éboulis de gros rochers, enfin depuis peu la carrière dispose de tout un système de tuyaux qui diffusent de l’air à mi profondeur, cela se traduit, quand le système est en route, par un rideau de petites bulles à une vingtaine de cm de la paroi.');

INSERT INTO [User_Diveplace]([user_Id],diveplace_Id,evaluation,createdAt) VALUES
    (1,1,1,GETDATE()),
    (1,2,5,GETDATE()),
    (1,3,3,GETDATE()),
    (1,4,2,GETDATE()),
    (1,5,5,GETDATE()),
    (1,6,4,GETDATE()),
    (1,7,2,GETDATE()),
    (1,8,1,GETDATE()),
    (1,9,4,GETDATE()),
    (1,10,5,GETDATE()),
    (1,11,1,GETDATE()),
    (1,12,3,GETDATE()),
    (1,13,3,GETDATE()),
    (1,14,2,GETDATE()),
    

    (2,1,0,GETDATE()),
    (2,2,2,GETDATE()),
    (2,3,3,GETDATE()),
    (2,4,4,GETDATE()),
    (2,5,5,GETDATE()),
    (2,6,4,GETDATE()),
    (2,7,3,GETDATE()),
    (2,8,3,GETDATE()),
    (2,9,4,GETDATE()),
    (2,10,5,GETDATE()),
    (2,11,1,GETDATE()),
    (2,12,2,GETDATE()),
    (2,13,4,GETDATE()),
    (2,14,3,GETDATE());
   
INSERT INTO Club([Name],createdAt, isActive,adress_Id,creator_Id,organisation_id)VALUES
    ('EYD',GETDATE(),1,1,1,1),
    ('Virtal-Sso',GETDATE(),1,2,2,2),
    ('Virtual-Lifras',GETDATE(),1,3,3,3),
    ('Virtual-Ffessm',GETDATE(),1,4,4,4);

INSERT INTO [User_Club](user_Id,club_Id,createdAt,validation)VALUES
    (1,1,GETDATE(),1),
    (1,2,GETDATE(),0),
    (2,2,GETDATE(),1),
    (2,1,GETDATE(),0),
    (3,3,GETDATE(),1),
    (3,2,GETDATE(),0),
    (4,4,GETDATE(),1),
    (4,1,GETDATE(),0);

INSERT INTO [Event]([name], startDate, endDate, createdAt, isActive, diveplace_Id,creator_Id, training_Id ,club_Id) VALUES
    ('Explo 1','2023-01-01','2023-01-02', GETDATE(),1,1,1,null,null),
    ('N2 Dongelbert','2024-05-01','2024-05-02', GETDATE(),1,2,2,1,1),
    ('N1 Dour','2024-05-01','2024-05-02', GETDATE(),1,3,1,2,2),
    ('N2 Ekeren','2024-06-01','2024-06-02', GETDATE(),1,4,2,3,3),
    ('N1 Floreffe','2024-07-10','2024-07-12', GETDATE(),1,5,1,4,4),
    ('N2 La gombe','2024-06-01','2024-08-02', GETDATE(),1,6,2,5,1),
    ('Explo 2','2024-12-01','2024-12-02', GETDATE(),1,7,1,null,null),
    ('N2 Lessine','2024-05-08','2024-05-09', GETDATE(),1,8,2,8,2),
    ('N2 Lillé','2024-05-17','2024-05-25', GETDATE(),1,9,2,9,3),
    ('N1 Opperbais','2024-10-10','2024-10-10', GETDATE(),1,10,1,10,4),
    ('Explo 3','2024-11-01','2024-11-02', GETDATE(),1,11,2,null,null),
    ('N1 V2E','2024-08-15','2024-08-15', GETDATE(),1,12,1,11,1),
    ('N3 Voldelee','2024-08-18','2024-08-19', GETDATE(),1,13,2,12,2);

INSERT INTO Divelog(diveType,[description],duration,maxDeep, airTemperature, waterTemperature,diveDate, createdAt,isActive,[user_Id],event_Id) VALUES
    ('N1','chouette',45,15,15,15,'2022-01-01',GETDATE(),1,1,null),
    ('N2','chouette',55,20,16,15,'2022-01-02',GETDATE(),1,2,2),
    ('N3','chouette',50,25,18,16,'2022-01-03',GETDATE(),1,3,1),
    ('N4','chouette',52,18,15,16,'2022-01-04',GETDATE(),1,1,3),
    ('N1','chouette',47,30,20,16,'2022-01-05',GETDATE(),1,2,4),
    ('N2','chouette',59,35,21,16,'2022-01-06',GETDATE(),1,3,5),
    ('N3','chouette',62,16,15,16,'2022-01-07',GETDATE(),1,1,1),
    ('N4','chouette',45,18,14,16,'2022-01-08',GETDATE(),1,2,6),
    ('N1','chouette',46,20,15,17,'2022-01-09',GETDATE(),1,1,1),
    ('N3','chouette',42,14,15,17,'2022-01-10',GETDATE(),1,3,5);


INSERT INTO [Participe](user_Id,event_Id,createdAt,validation)VALUES
    (1,1,GETDATE(),1),
    (1,2,GETDATE(),1),
    (1,3,GETDATE(),1),
    (1,4,GETDATE(),1),
    (2,1,GETDATE(),1),
    (2,2,GETDATE(),1),
    (2,6,GETDATE(),0),
    (3,1,GETDATE(),0),
    (3,4,GETDATE(),0),
    (3,10,GETDATE(),0),
    (3,9,GETDATE(),0);


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

INSERT INTO [Message](sender_Id, reciever_Id, content,createdAt,isActive,isRead)VALUES
   (1,2,'coucou',GETDATE(),1,1),    
   (1,3,'coucou',GETDATE(),1,1),    
   (1,4,'coucou',GETDATE(),1,1), 
   (2,1,'coucou',GETDATE(),1,1), 
   (2,3,'coucou',GETDATE(),1,1), 
   (2,4,'coucou',GETDATE(),1,1), 
   (3,1,'coucou',GETDATE(),1,1), 
   (3,2,'coucou',GETDATE(),1,1), 
   (3,4,'coucou',GETDATE(),1,1), 
   (4,1,'coucou',GETDATE(),1,1), 
   (4,2,'coucou',GETDATE(),1,1), 
   (4,3,'coucou',GETDATE(),1,1), 
   (4,3,'coucou',GETDATE(),1,1), 
   (1,2,'coucou',GETDATE(),1,1),    
   (1,3,'coucou',GETDATE(),1,1),    
   (1,4,'coucou',GETDATE(),1,1), 
   (2,1,'coucou',GETDATE(),1,1), 
   (2,3,'coucou',GETDATE(),1,1), 
   (2,4,'coucou',GETDATE(),1,1), 
   (3,1,'coucou',GETDATE(),1,1), 
   (3,2,'coucou',GETDATE(),1,1), 
   (3,4,'coucou',GETDATE(),1,1), 
   (4,1,'coucou',GETDATE(),1,1), 
   (4,2,'coucou',GETDATE(),1,1), 
   (4,3,'coucou',GETDATE(),1,1), 
   (4,3,'coucou',GETDATE(),1,1);
   
 