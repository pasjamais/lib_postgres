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

INSERT INTO public.action_type (id, name, _is_deleted, operation) VALUES (1, 'поступление', NULL, true);
INSERT INTO public.action_type (id, name, _is_deleted, operation) VALUES (2, 'списание', NULL, false);
INSERT INTO public.action_type (id, name, _is_deleted, operation) VALUES (3, 'перемещение', NULL, true);
INSERT INTO public.action_type (id, name, _is_deleted, operation) VALUES (4, 'выдача', NULL, false);
INSERT INTO public.action_type (id, name, _is_deleted, operation) VALUES (5, 'возврат', NULL, true);

INSERT INTO public.book_format (id, name, _is_deleted) OVERRIDING SYSTEM VALUE VALUES (1, 'бумажный', NULL);
INSERT INTO public.book_format (id, name, _is_deleted) OVERRIDING SYSTEM VALUE VALUES (2, 'электронный', NULL);
INSERT INTO public.book_format (id, name, _is_deleted) OVERRIDING SYSTEM VALUE VALUES (3, 'аудиокнига', NULL);

INSERT INTO public.genre (id, name, _is_deleted) VALUES (2, 'Фантастика', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (3, 'Поэзия', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (4, 'Программирование', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (5, 'Ислам', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (6, 'Христианство', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (7, 'Автомобиль', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (8, 'Философия', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (9, 'Детектив', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (10, 'Словарь', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (11, 'Здоровье', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (12, 'Экономика', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (13, 'Классика русская', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (14, 'Классика зарубежная', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (15, 'Астрономия', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (16, 'Физика', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (17, 'Химия', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (19, 'Зоология', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (20, 'Фольклор', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (21, 'Сад и огород', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (22, 'Биография', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (23, 'Драгметаллы и камни', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (26, 'Магаданская литература', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (27, 'Эзотерика', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (28, 'Кулинария', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (29, 'Собаководство', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (30, 'Роман зарубежный', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (31, 'ВОВ-2', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (32, 'Природа', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (33, 'Города и страны', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (34, 'Домоводство', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (35, 'Социализм', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (36, 'Демография', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (38, 'История России', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (39, 'Политика', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (41, 'Психология', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (42, 'Фантасмагория', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (43, 'Финансы', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (44, 'Фотоальбом', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (45, 'Спорт', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (46, 'Коллекционирование', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (48, 'Математика', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (49, 'Туризм', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (50, 'Роман исторический', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (51, 'Личная эффективность', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (52, 'Информатика', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (53, 'Социология', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (54, 'Роман российский современный', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (55, 'Драма', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (56, 'История', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (57, 'Юмор', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (58, 'Детская литература', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (59, 'Военное дело', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (61, 'Литературоведение', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (62, 'Конспирология', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (63, 'Язык арабский', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (64, 'Сказка', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (65, 'Приключения', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (66, 'Путешествие', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (69, 'Логика', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (70, 'Бизнес', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (71, 'Религиоведение', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (72, 'Теология', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (73, 'Антропология', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (75, 'Санкт-Петербург', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (77, 'Алхимия', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (79, 'Магия', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (80, 'Буддизм', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (81, 'Поэма', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (83, 'Повесть', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (84, 'Криптография', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (47, 'Эпистемология', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (1, 'История Колымы и ГУЛАГ', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (40, 'Законодательство', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (85, 'Античная литература', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (67, 'Эпос европейский', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (86, 'Индийский эпос', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (87, 'Инвестиции', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (88, 'Менеджмент', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (89, 'Боевик', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (90, 'Публицистика', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (74, 'Драматургия', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (91, 'Роман любовный', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (92, 'Фэнтези', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (82, 'Графический роман', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (18, 'Искусствоведение', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (93, 'Древнерусская литература', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (94, 'Мемуары', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (95, 'Сатира', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (104, 'Научно-популярное', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (96, 'Триллер', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (78, 'Традиционализм', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (60, 'Эротическая литература', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (68, 'Языческая литература', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (97, 'Антиутопия', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (98, 'Трэш', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (99, 'Военная проза', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (100, 'Вестерн', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (101, 'Сборник цитат', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (102, 'Интервью', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (37, 'Советское', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (25, 'Антисоветское', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (24, 'Рассказ', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (103, 'Либерализм', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (105, 'Медицина', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (106, 'Социальная психология', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (107, 'Культурология', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (108, 'Техническое', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (109, 'История всемирная ', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (110, 'Задачник', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (111, 'Музыка', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (112, 'Дизайн', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (113, 'Архитектура', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (114, 'Искусство фотографии', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (115, 'Изобразительное искусство', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (116, 'Кинематограф', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (117, 'Театр', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (76, 'Иудаизм и каббала', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (118, 'Путеводитель', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (119, 'Питание и диеты', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (121, 'Язык английский', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (120, 'Язык русский', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (122, 'Атеизм', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (123, 'Язык французский', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (124, 'Роман французский современный', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (125, 'Юридическое', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (126, 'Хобби', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (127, 'Комикс', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (128, 'Комикс французский', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (129, 'Манга', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (130, 'Ужасы', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (131, 'История Франции', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (132, 'История Великобритании', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (133, 'История США', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (134, 'Боевое искусство', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (135, 'Классика французская', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (136, 'Класска английская', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (137, 'Классика американская', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (138, 'Роман американский современный', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (139, 'Эссе', NULL);
INSERT INTO public.genre (id, name, _is_deleted) VALUES (140, 'История Канады', NULL);

INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (1, 'Français', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (2, 'English', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (3, 'Русский', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (4, 'العربية', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (5, 'Украинский', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (6, 'Немецкий', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (7, 'Польский', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (8, 'Шведский', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (9, 'Чешский', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (10, 'Бенгальский', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (11, 'Татарский', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (12, 'Испанский', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (13, 'Китайский', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (14, 'Итальянский', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (15, 'Корейский', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (16, 'Японский', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (17, 'Норвежский', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (18, 'Узбекский', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (19, 'Санскрит', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (20, 'Греческий', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (21, 'Иврит', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (22, 'Арамейский', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (23, 'Латинский', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (24, 'Фарси', NULL, NULL);
INSERT INTO public.language (id, name, bref, _is_deleted) VALUES (25, 'Датский', NULL, NULL);


INSERT INTO public.mark (id, name, _is_deleted) OVERRIDING SYSTEM VALUE VALUES (1, 'невозможно', NULL);
INSERT INTO public.mark (id, name, _is_deleted) OVERRIDING SYSTEM VALUE VALUES (2, 'ужасно', NULL);
INSERT INTO public.mark (id, name, _is_deleted) OVERRIDING SYSTEM VALUE VALUES (3, 'слабо', NULL);
INSERT INTO public.mark (id, name, _is_deleted) OVERRIDING SYSTEM VALUE VALUES (4, 'так себе', NULL);
INSERT INTO public.mark (id, name, _is_deleted) OVERRIDING SYSTEM VALUE VALUES (5, 'нормально', NULL);
INSERT INTO public.mark (id, name, _is_deleted) OVERRIDING SYSTEM VALUE VALUES (6, 'недурно', NULL);
INSERT INTO public.mark (id, name, _is_deleted) OVERRIDING SYSTEM VALUE VALUES (7, 'хорошо', NULL);
INSERT INTO public.mark (id, name, _is_deleted) OVERRIDING SYSTEM VALUE VALUES (8, 'примечательно', NULL);
INSERT INTO public.mark (id, name, _is_deleted) OVERRIDING SYSTEM VALUE VALUES (9, 'круто', NULL);
INSERT INTO public.mark (id, name, _is_deleted) OVERRIDING SYSTEM VALUE VALUES (10, 'изумительно', NULL);


INSERT INTO public.people (id, name, _is_deleted) VALUES (1, 'Я', NULL);


INSERT INTO public.place (id, name, comment, _is_deleted) VALUES (1, 'У меня дома', NULL, NULL);


INSERT INTO public.city (id, name, _is_deleted) VALUES (1, 'Санкт-Петербург', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (2, 'Москва', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (3, 'Магадан', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (4, 'Париж', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (5, 'Ленинград', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (6, 'Хабаровск', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (7, 'Пермь', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (8, 'Днепропетровск', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (9, 'Харьков', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (10, 'Ташкент', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (11, 'Кишинёв', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (12, 'Алма-Ата', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (13, 'Казань', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (14, 'Екатеринбург', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (15, 'Чебоксары', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (16, 'Рига', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (17, 'Ростов', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (18, 'Махачкала', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (19, 'Можайск', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (20, 'Марсель', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (21, 'Лион', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (22, 'Тулуза', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (23, 'Ницца', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (24, 'Нант', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (25, 'Страсбург', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (26, 'Монпелье', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (27, 'Бордо', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (28, 'Лондон', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (29, 'Бирмингем', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (30, 'Глазго', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (31, 'Манчестер', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (32, 'Эдинбург', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (33, 'Ливерпуль', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (34, 'Стамбул', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (35, 'Дамаск', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (36, 'Тунис', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (37, 'Нью-Йорк', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (38, 'Лос-Анджелес', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (39, 'Вашингтон', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (40, 'Филадельфия', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (41, 'Даллас', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (42, 'Сиэтл', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (43, 'Каир', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (44, 'Торонто', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (45, 'Монреаль', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (46, 'Калгари', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (47, 'Оттава', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (48, 'Эдмонтон', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (49, 'Ванкувер', NULL);
INSERT INTO public.city (id, name, _is_deleted) VALUES (50, 'Квебек', NULL);

INSERT INTO public.query (id, name, text, _is_deleted) OVERRIDING SYSTEM VALUE VALUES (1, 'новая запись в локацию', 'insert into public.location (operation,book,place,owner,action) values (true, 149, 1,1,12 );
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


