CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';
CREATE TABLE recipe(
  id INT NOT NULL primary key AUTO_INCREMENT comment 'primary key',
  title VARCHAR(255) not null,
  desription VARCHAR(255) not null,
  cooktime INT not null,
  prepTime INT not null,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  creatorId VARCHAR(255) not null,
  FOREIGN KEY (creatorId) REFERENCES accounts(id)
) default charset utf8;
CREATE TABLE steps(
  id int NOT NULL primary key AUTO_INCREMENT comment 'primary key',
  body VARCHAR(255) not null,
  recipeId int not null,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  FOREIGN KEY (recipeId) REFERENCES recipe(id),
  creatorId VARCHAR(255) not null,
  FOREIGN KEY (creatorId) REFERENCES accounts(id)
) default charset utf8;