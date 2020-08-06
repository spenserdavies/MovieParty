USE movieparty;

-- CREATE TABLE groups (
--     id int NOT NULL AUTO_INCREMENT,
--     name VARCHAR(255) NOT NULL,
--     description VARCHAR(255) NOT NULL,
--     userId VARCHAR(255),
--     INDEX userId (userId),  
--     PRIMARY KEY (id)
-- );

-- CREATE TABLE members (
--     id int NOT NULL AUTO_INCREMENT,
--     username VARCHAR(255) NOT NULL,
--     userId VARCHAR(255),
--     img VARCHAR(255),
--     INDEX userId (userId),
--     PRIMARY KEY (id)
-- );
-- CREATE TABLE movies (
--     id int NOT NULL AUTO_INCREMENT,
--     title VARCHAR(255) NOT NULL,
--     img VARCHAR(255),
--     PRIMARY KEY (id)
-- );

-- CREATE TABLE groupmovies (
--     id int NOT NULL AUTO_INCREMENT,
--     groupId int NOT NULL,
--     movieId int NOT NULL,
--     userId VARCHAR(255) NOT NULL,
--     votes INT DEFAULT 0,

--     PRIMARY KEY (id),
--     INDEX (groupId, movieId),
--     INDEX (userId),

--     FOREIGN KEY (groupId)
--         REFERENCES groups(id)
--         ON DELETE CASCADE,

--     FOREIGN KEY (movieId)
--         REFERENCES movies(id)
--         ON DELETE CASCADE
-- )

-- CREATE TABLE groupmembers (
--     id int NOT NULL AUTO_INCREMENT,
--     groupId int NOT NULL,
--     memberId int NOT NULL,
--     userId VARCHAR(255) NOT NULL,
--     status VARCHAR(255) NOT NULL,
--     hasVoted TINYINT,

--     PRIMARY KEY (id),
--     INDEX (groupId, memberId),
--     INDEX (userId),

--     FOREIGN KEY (groupId)
--         REFERENCES groups(id)
--         ON DELETE CASCADE,

--     FOREIGN KEY (memberId)
--         REFERENCES members(id)
--         ON DELETE CASCADE
-- )

-- -- USE THIS LINE FOR GET KEEPS BY VAULTID
-- SELECT 
-- k.*,
-- vk.id as vaultKeepId
-- FROM vaultkeeps vk
-- INNER JOIN keeps k ON k.id = vk.keepId 
-- WHERE (vaultId = @vaultId AND vk.userId = @userId) 



-- -- USE THIS TO CLEAN OUT YOUR DATABASE
-- DROP TABLE IF EXISTS groups;
-- DROP TABLE IF EXISTS members;
-- DROP TABLE IF EXISTS movies;
-- DROP TABLE IF EXISTS groupmovies;
-- DROP TABLE IF EXISTS groupmembrs;
