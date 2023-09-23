SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

INSERT INTO public.action_type (id, name, _is_deleted, operation) VALUES (1, 'recette', NULL, true);
INSERT INTO public.action_type (id, name, _is_deleted, operation) VALUES (2, 'débit', NULL, false);
INSERT INTO public.action_type (id, name, _is_deleted, operation) VALUES (3, 'déplacement', NULL, true);
INSERT INTO public.action_type (id, name, _is_deleted, operation) VALUES (4, 'prêt', NULL, false);
INSERT INTO public.action_type (id, name, _is_deleted, operation) VALUES (5, 'remboursement', NULL, true);

INSERT INTO public.book_format (id, name, _is_deleted) OVERRIDING SYSTEM VALUE VALUES (1, 'en papier', NULL);
INSERT INTO public.book_format (id, name, _is_deleted) OVERRIDING SYSTEM VALUE VALUES (2, 'électronique', NULL);
INSERT INTO public.book_format (id, name, _is_deleted) OVERRIDING SYSTEM VALUE VALUES (3, 'livre audio', NULL);


INSERT INTO public.genre (id, name, _is_deleted) VALUES (2, 'Roman fantastique', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (3, 'Poésie', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (4, 'Programmation', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (5, 'Études islamiques', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (6, 'Christianisme', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (7, 'Automobilisme', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (8, 'Philosophie', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (9, 'Roman policier', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (10, 'Dictionnaire', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (11, 'Santé', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (12, 'Économie', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (13, 'Classiques russes', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (14, 'Classiques étrangers', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (15, 'Astronomie', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (16, 'Physique', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (17, 'Chimie', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (19, 'Zoologie', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (20, 'Folklore', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (21, 'Jardinage', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (22, 'Biographie', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (23, 'Métaux et pierres précieux', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (26, 'Littérature magadienne', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (27, 'Ésotérisme', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (28, 'Cuisson', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (29, 'Élevage de chiens', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (30, 'Roman étranger', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (31, 'Seconde Guerre mondiale', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (32, 'Nature', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (33, 'Villes et pays', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (34, 'Arts ménagers', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (35, 'Socialisme', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (36, 'Démographie', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (38, 'Histoire de la Russie', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (39, 'Politique', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (41, 'Psychologie', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (42, 'Fantasmagorie', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (43, 'Finance', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (44, 'Album photo', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (45, 'Sport', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (46, 'Collectionnement', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (48, 'Mathématiques', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (49, 'Tourisme', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (50, 'Roman historique', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (51, 'Efficacité personnelle', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (52, 'Informatique', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (53, 'Sociologie', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (54, 'Roman russe contemporain', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (55, 'Drame', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (56, 'Histoire', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (57, 'Humour', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (58, 'Littérature jeunesse', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (59, 'Guerre', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (61, 'Etudes littéraires', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (62, 'Théorie du complot', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (63, 'Langue arabe', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (64, 'Conte de fées', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (65, 'Aventures', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (66, 'Voyage', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (69, 'Logique', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (70, 'Entreprise', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (71, 'Études religieuses', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (72, 'Théologie', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (73, 'Anthropologie', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (75, 'Saint-Pétersbourg', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (77, 'Alchimie', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (79, 'Magie', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (80, 'Bouddhisme', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (81, 'Poème', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (83, 'Conte', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (84, 'Cryptographie', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (47, 'Épistémologie', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (1, 'Histoire de la Kolyma et du Goulag', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (40, 'Législation', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (85, 'Littérature ancienne', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (67, 'Épopée de l''Europe', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (86, 'Épopée indienne', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (87, 'Investissements', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (88, 'Gestion', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (89, 'Roman d''action', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (90, 'Publicisme', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (74, 'Dramaturgie', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (91, 'Roman d''amour', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (92, 'Fantaisie', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (82, 'Roman graphique', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (18, 'Critique d''art', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (93, 'Littérature russe ancienne', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (94, 'Mémoires', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (95, 'Satire', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (104, 'Science populaire', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (96, 'Thriller', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (78, 'Traditionalisme', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (60, 'Littérature érotique', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (68, 'Littérature païenne', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (97, 'Dystopie', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (98, 'Blanche', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (99, 'Prose de guerre', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (100, 'Western', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (101, 'Recueil de citations', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (102, 'Entretien', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (37, 'Soviétique', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (25, 'Antisoviétique', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (24, 'Récit', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (103, 'Libéralisme', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (105, 'Médecine', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (106, 'Psychologie sociale', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (107, 'Culturologie', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (108, 'Technique', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (109, 'Histoire du monde', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (110, 'Livre à problèmes', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (111, 'Musique', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (112, 'Conception', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (113, 'Architecture', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (114, 'Art de la photographie', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (115, 'Art', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (116, 'Cinéma', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (117, 'Théâtre', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (76, 'Judaïsme et Kabbale', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (118, 'Guide', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (119, 'Nutrition et régimes', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (121, 'Langue anglaise', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (120, 'Langue russe', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (122, 'Athéisme', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (123, 'Langue français', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (124, 'Roman français contemporain', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (125, 'Juridique', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (126, 'Loisirs', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (127, 'Bande dessinée américaine', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (128, 'Bande dessinée', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (129, 'Manga', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (130, 'Roman d’horreur', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (131, 'Histoire de France', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (132, 'Histoire de la Grande-Bretagne', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (133, 'Histoire des États-Unis', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (134, 'Arts martiaux', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (135, 'Classique français', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (136, 'Classique anglais', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (137, 'Classique américain', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (138, 'Roman contemporain américain', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (139, 'Essai', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (140, 'Histoire du Canada', NULL);

INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (1, 'Français', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (2, 'Anglais', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (3, 'Russe', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (4, 'Arabe', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (5, 'Ukrainien', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (6, 'Allemand', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (7, 'Polonais', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (8, 'Suédois', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (9, 'Tchèque', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (10, 'Bengale', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (11, 'Tatar', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (12, 'Espagnol', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (13, 'Chinois', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (14, 'Italien', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (15, 'Coréen', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (16, 'Japonais', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (17, 'Norvégien', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (18, 'Ouzbek', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (19, 'Sanskrit', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (20, 'Grec', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (21, 'Hébreu', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (22, 'Araméen', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (23, 'Latin', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (24, 'Farsi', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (25, 'Danois', NULL, NULL);


INSERT INTO public.mark (id, name, _is_deleted) OVERRIDING SYSTEM VALUE VALUES (1, 'impossible', NULL);
INSERT INTO public.mark (id, name, _is_deleted) OVERRIDING SYSTEM VALUE VALUES (2, 'terrible', NULL);
INSERT INTO public.mark (id, name, _is_deleted) OVERRIDING SYSTEM VALUE VALUES (3, 'faible', NULL);
INSERT INTO public.mark (id, name, _is_deleted) OVERRIDING SYSTEM VALUE VALUES (4, 'pas tellement', NULL);
INSERT INTO public.mark (id, name, _is_deleted) OVERRIDING SYSTEM VALUE VALUES (5, 'mouais', NULL);
INSERT INTO public.mark (id, name, _is_deleted) OVERRIDING SYSTEM VALUE VALUES (6, 'pas mal', NULL);
INSERT INTO public.mark (id, name, _is_deleted) OVERRIDING SYSTEM VALUE VALUES (7, 'bien', NULL);
INSERT INTO public.mark (id, name, _is_deleted) OVERRIDING SYSTEM VALUE VALUES (8, 'notable', NULL);
INSERT INTO public.mark (id, name, _is_deleted) OVERRIDING SYSTEM VALUE VALUES (9, 'cool', NULL);
INSERT INTO public.mark (id, name, _is_deleted) OVERRIDING SYSTEM VALUE VALUES (10, 'incroyable', NULL);


INSERT INTO public.people (id, name, _is_deleted) VALUES (1, 'Mol', NULL);


INSERT INTO public.place (id, name, comment, _is_deleted) VALUES (1, 'Chez moi', NULL, NULL);


INSERT INTO public.city (id, name, _is_deleted) VALUES (1, 'Saint-Pétersbourg', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (2, 'Moscou', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (3, 'Magadan', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (4, 'Paris', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (5, 'Leningrad', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (6, 'Khabarovsk', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (7, 'Perm', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (8, 'Dniepropetrovsk', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (9, 'Kharkiv', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (10, 'Tachkent', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (11, 'Kichinev', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (12, 'Alma-Ata', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (13, 'Kazan', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (14, 'Ekaterinbourg', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (15, 'Tcheboksary', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (16, 'Riga', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (17, 'Rostov', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (18, 'Makhatchkala', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (19, 'Mojaïsk', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (20, 'Marseille', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (21, 'Lyon', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (22, 'Toulouse', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (23, 'Nice', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (24, 'Nantes', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (25, 'Strasbourg', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (26, 'Montpellier', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (27, 'Bordeaux', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (28, 'Londres', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (29, 'Birmingham', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (30, 'Glasgow', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (31, 'Manchester', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (32, 'Edinbourg', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (33, 'Liverpool', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (34, 'Istanbul', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (35, 'Damas', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (36, 'Tunis', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (37, 'New York', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (38, 'Los Angeles', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (39, 'Washington', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (40, 'Philadelphie', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (41, 'Dallas', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (42, 'Seattle', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (43, 'Caire, le ', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (44, 'Toronto', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (45, 'Montréal', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (46, 'Calgary', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (47, 'Ottawa', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (48, 'Edmonton', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (49, 'Vancouver', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (50, 'Québec', NULL);

INSERT INTO public.query (id, name, text, _is_deleted) OVERRIDING SYSTEM VALUE VALUES (1, 'nouvelle entrée à l''emplacement', 'insert into public.location (operation,book,place,owner,action) values (true, 149, 1,1,12 );
', NULL);
INSERT INTO public.query (id, name, text, _is_deleted) OVERRIDING SYSTEM VALUE VALUES (2, 'where is book with :book_id_parameter', 'SELECT 
	ACTIONTABLE.DATE AS "Дата",
	ACTION_TYPE.NAME AS "Действие",
	PLACE.NAME AS "Место",
	ACTIONTABLE.COMMENT AS "Движ."
FROM BOOK
	LEFT JOIN LOCATION ON LOCATION.BOOK = BOOK.ID
	LEFT JOIN PUBLIC.ACTION AS ACTIONTABLE ON LOCATION.ACTION = ACTIONTABLE.ID
	LEFT JOIN PLACE ON LOCATION.PLACE = PLACE.ID
	LEFT JOIN PUBLIC.ACTION ON LOCATION.ACTION = ACTION.ID
	LEFT JOIN ACTION_TYPE ON ACTION_TYPE.ID = ACTION.ACTION_TYPE
WHERE BOOK.ID = :book_id_parameter
ORDER BY ACTIONTABLE.DATE;', NULL);
INSERT INTO public.query (id, name, text, _is_deleted) OVERRIDING SYSTEM VALUE VALUES (3, 'get all recommendation records', ' SELECT 
 	source_toread_another.name AS sourceAnother_Text,
   	source_author_table.name AS author_Source_Text,
 	toread_author_table.name AS author_ToRead_Text,
	source_art."Автор(ы)" || '' - '' ||  source_art."Название"    AS art_Source_Text,
    toread_art."Автор(ы)"  ||  '' - ''  ||   toread_art.Название 	 AS art_ToRead_Text,
 	art_to_read.*
   FROM art_to_read
     LEFT JOIN author source_author_table ON art_to_read.source_author_id = source_author_table.id
	 LEFT JOIN author toread_author_table ON art_to_read.toread_author_id = toread_author_table.id
     LEFT JOIN view_arts_with_id toread_art ON art_to_read.toread_art_id = toread_art.id
 	 LEFT JOIN view_arts_with_id source_art ON art_to_read.source_art_id = source_art.id
  	 LEFT JOIN	source_toread_another	ON	art_to_read.source_another_id = source_toread_another.id', NULL);

SELECT pg_catalog.setval('public.action_type_id_seq', 5, true);
SELECT pg_catalog.setval('public.book_format_id_seq', 3, true);
SELECT pg_catalog.setval('public.genre_id_seq', 140, true);
SELECT pg_catalog.setval('public.language_id_seq', 25, true);
SELECT pg_catalog.setval('public.mark_id_seq', 10, true);
SELECT pg_catalog.setval('public.people_id_seq', 1, true);
SELECT pg_catalog.setval('public.place_id_seq', 1, true);
SELECT pg_catalog.setval('public.query_id_seq', 3, true);
SELECT pg_catalog.setval('public."City_id_seq"', 50, true);


