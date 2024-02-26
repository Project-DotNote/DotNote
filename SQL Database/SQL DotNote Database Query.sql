create schema DotNote;

use DotNote;

create table DotNoteUser
(
    Id char(36) not null primary key,
    Username varchar(100) not null,
    Email varchar(100) not null,
    PasswordHash varchar(255) not null,
    ProfilePicture varchar(255),
    LastLogin datetime,
    CreatedAt timestamp default current_timestamp
);

create table Note
(
	Id char(36) primary key not null,
    Title varchar(255) not null,
    Subtitle varchar(255) null,
    NoteText text null,
    UserId char(36) not null,
    CreatedAt timestamp default current_timestamp,
    UpdatedAt datetime,
    NoteStatus enum('active', 'deleted'),
    foreign key(UserId) references DotNoteUser(Id)
);

create table DotNoteGroup
(
	Id char(36) not null primary key,
    GroupName varchar(100) not null,
    UserId char(36) not null,
    CreatedAt timestamp default current_timestamp,
    foreign key(UserId) references DotNoteUser(Id)
);

create table DotNoteUpdate 
(
	Id varchar(36) not null primary key,
    Title varchar(255) not null,
    UpdateDescription text null,
    CreatedAt timestamp default current_timestamp
);