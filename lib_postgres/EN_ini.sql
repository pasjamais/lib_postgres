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

INSERT INTO public.action_type (id, name, _is_deleted, operation) VALUES (1, 'arrival', NULL, true);
INSERT INTO public.action_type (id, name, _is_deleted, operation) VALUES (2, 'disposal', NULL, false);
INSERT INTO public.action_type (id, name, _is_deleted, operation) VALUES (3, 'movement', NULL, true);
INSERT INTO public.action_type (id, name, _is_deleted, operation) VALUES (4, 'issue', NULL, false);
INSERT INTO public.action_type (id, name, _is_deleted, operation) VALUES (5, 'return', NULL, true);

INSERT INTO public.book_format (id, name, _is_deleted) OVERRIDING SYSTEM VALUE VALUES (1, 'paper', NULL);
INSERT INTO public.book_format (id, name, _is_deleted) OVERRIDING SYSTEM VALUE VALUES (2, 'electronic', NULL);
INSERT INTO public.book_format (id, name, _is_deleted) OVERRIDING SYSTEM VALUE VALUES (3, 'audiobook', NULL);

INSERT INTO public.genre (id, name, _is_deleted) VALUES (2, 'Fantastic', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (3, 'Poetry', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (4, 'Programming', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (5, 'Islamic studies', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (6, 'Christianity', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (7, 'Automobile', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (8, 'Philosophy', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (9, 'Detective', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (10, 'Dictionary', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (11, 'Health', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (12, 'Economics', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (13, 'Russian classics', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (14, 'Foreign classics', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (15, 'Astronomy', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (16, 'Physics', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (17, 'Chemistry', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (19, 'Zoology', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (20, 'Folklore', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (21, 'Garden', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (22, 'Biography', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (23, 'Precious metals and stones', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (26, 'Magadan literature', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (27, 'Esoterics', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (28, 'Cooking', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (29, 'Dog Breeding', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (30, 'Foreign Novel', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (31, 'WWII', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (32, 'Nature', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (33, 'Cities and Countries', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (34, 'Housekeeping', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (35, 'Socialism', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (36, 'Demography', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (38, 'Russian history', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (39, 'Politics', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (41, 'Psychology', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (42, 'Phantasmagoria', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (43, 'Finance', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (44, 'Photo Album', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (45, 'Sport', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (46, 'Collecting', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (48, 'Mathematics', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (49, 'Tourism', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (50, 'Historical novel', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (51, 'Personal effectiveness', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (52, 'Computer science', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (53, 'Sociology', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (54, 'Russian contemporary novel', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (55, 'Drama', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (56, 'History', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (57, 'Humor', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (58, 'Children''s literature', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (59, 'Warfare', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (61, 'Literary Studies', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (62, 'Conspiracy theory', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (63, 'Language Arabic', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (64, 'Fairy tale', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (65, 'Adventures', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (66, 'Journey', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (69, 'Logics', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (70, 'Business', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (71, 'Religious Studies', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (72, 'Theology', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (73, 'Anthropology', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (75, 'Saint Petersburg', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (77, 'Alchemy', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (79, 'Magic', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (80, 'Buddhism', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (81, 'Poem', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (83, 'Tale', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (84, 'Cryptography', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (47, 'Epistemology', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (1, 'History of Kolyma and the Gulag', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (40, 'Legislation', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (85, 'Ancient literature', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (67, 'European epic', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (86, 'Indian epic', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (87, 'Investments', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (88, 'Management', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (89, 'Action', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (90, 'Publicism', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (74, 'Dramaturgy', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (91, 'Love Novel', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (92, 'Fantasy', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (82, 'Graphic Novel', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (18, 'Art Criticism', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (93, 'Old Russian Literature', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (94, 'Memoirs', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (95, 'Satire', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (104, 'Popular Science', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (96, 'Thriller', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (78, 'Traditionalism', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (60, 'Erotic', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (68, 'Pagan Literature', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (97, 'Dystopia', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (98, 'Trash', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (99, 'Military prose', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (100, 'Western', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (101, 'Collection of quotes', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (102, 'Interview', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (37, 'Soviet', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (25, 'Anti-Soviet', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (24, 'Story', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (103, 'Liberalism', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (105, 'Medicine', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (106, 'Social Psychology', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (107, 'Culturology', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (108, 'Technical', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (109, 'World History', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (110, 'Problem book', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (111, 'Music', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (112, 'Design', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (113, 'Architecture', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (114, 'Art of Photography', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (115, 'Art', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (116, 'Cinema', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (117, 'Theater', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (76, 'Judaism and Kabbalah', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (118, 'Guide', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (119, 'Nutrition and Diets', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (121, 'English language', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (120, 'Russian language', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (122, 'Atheism', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (123, 'French Language', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (124, 'French modern novel', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (125, 'Legal', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (126, 'Hobby', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (127, 'Comics', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (128, 'French comics', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (129, 'Manga', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (130, 'Horror', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (131, 'History of France', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (132, 'History of Great Britain', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (133, 'History of the USA', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (134, 'Martial arts', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (135, 'French classic', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (136, 'English classic', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (137, 'American classic', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (138, 'American contemporary novel', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (139, 'Essay', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (140, 'History of Canada', NULL);

INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (1, 'French', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (2, 'English', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (3, 'Russian', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (4, 'Arabic', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (5, 'Ukrainian', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (6, 'German', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (7, 'Polish', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (8, 'Swedish', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (9, 'Czech', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (10, 'Bengal', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (11, 'Tatar', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (12, 'Spanish', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (13, 'Chinese', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (14, 'Italian', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (15, 'Italian', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (16, 'Japanese', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (17, 'Norwegian', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (18, 'Uzbek', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (19, 'Sanskrit', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (20, 'Greek', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (21, 'Hebrew', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (22, 'Aramaic', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (23, 'Latin', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (24, 'Farsi', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (25, 'Danish', NULL, NULL);


INSERT INTO public.mark (id, name, _is_deleted) OVERRIDING SYSTEM VALUE VALUES (1, 'Impossible', NULL);
INSERT INTO public.mark (id, name, _is_deleted) OVERRIDING SYSTEM VALUE VALUES (2, 'Terrible', NULL);
INSERT INTO public.mark (id, name, _is_deleted) OVERRIDING SYSTEM VALUE VALUES (3, 'Faintly', NULL);
INSERT INTO public.mark (id, name, _is_deleted) OVERRIDING SYSTEM VALUE VALUES (4, 'So-so', NULL);
INSERT INTO public.mark (id, name, _is_deleted) OVERRIDING SYSTEM VALUE VALUES (5, 'Average', NULL);
INSERT INTO public.mark (id, name, _is_deleted) OVERRIDING SYSTEM VALUE VALUES (6, 'Fine', NULL);
INSERT INTO public.mark (id, name, _is_deleted) OVERRIDING SYSTEM VALUE VALUES (7, 'Very good', NULL);
INSERT INTO public.mark (id, name, _is_deleted) OVERRIDING SYSTEM VALUE VALUES (8, 'Remarkable', NULL);
INSERT INTO public.mark (id, name, _is_deleted) OVERRIDING SYSTEM VALUE VALUES (9, 'Cool', NULL);
INSERT INTO public.mark (id, name, _is_deleted) OVERRIDING SYSTEM VALUE VALUES (10, 'Amazing', NULL);


INSERT INTO public.people (id, name, _is_deleted) VALUES (1, 'Me', NULL);


INSERT INTO public.place (id, name, comment, _is_deleted) VALUES (1, 'At my place', NULL, NULL);


INSERT INTO public.city (id, name, _is_deleted) VALUES (1, 'Saint Petersburg', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (2, 'Moscow', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (3, 'Magadan', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (4, 'Paris', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (5, 'Leningrad', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (6, 'Khabarovsk', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (7, 'Perm', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (8, 'Dnepropetrovsk', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (9, 'Kharkiv', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (10, 'Tashkent', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (11, 'Kishinev', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (12, 'Alma-Ata', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (13, 'Kazan', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (14, 'Ekaterinburg', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (15, 'Cheboksary', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (16, 'Riga', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (17, 'Rostov', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (18, 'Makhachkala', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (19, 'Mozhaisk', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (20, 'Marseilles', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (21, 'Lyon', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (22, 'Toulouse', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (23, 'Nice', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (24, 'Nantes', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (25, 'Strasbourg', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (26, 'Montpellier', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (27, 'Bordeaux', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (28, 'London', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (29, 'Birmingham', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (30, 'Glasgow', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (31, 'Manchester', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (32, 'Edinburgh', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (33, 'Liverpool', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (34, 'Istanbul', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (35, 'Damascus', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (36, 'Tunis', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (37, 'New York', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (38, 'Los Angeles', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (39, 'Washington', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (40, 'Philadelphia', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (41, 'Dallas', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (42, 'Seattle', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (43, 'Cairo', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (44, 'Toronto', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (45, 'Montreal', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (46, 'Calgary', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (47, 'Ottawa', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (48, 'Edmonton', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (49, 'Vancouver', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (50, 'Quebec', NULL);

INSERT INTO public.query (id, name, text, _is_deleted) OVERRIDING SYSTEM VALUE VALUES (1, 'new entry to location', 'insert into public.location (operation,book,place,owner,action) values (true, 149, 1,1,12 );
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


