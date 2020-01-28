create table subclass(subclass_name VARCHAR(100) , ala_tartozok_szama INT, megtalalas_eve Smallint, external_shell tinyint, kihalt tinyint, megjelenes_idoszaka varchar(40),
constraint subclass_pk primary key (subclass_name));

create table classification(subclass_name varchar(100), order_ varchar(100),family varchar(100),genus_name varchar(100), deep_able tinyint, cthulh_aproved tinyint,special_sensore varchar(120),
constraint genus_name_pk primary key (genus_name), 
constraint subclass_name_fk foreign key (subclass_name) references subclass(subclass_name));  


create table species(species_name varchar(100), felfedezes smallint, megjelenes varchar(20), genus_name varchar(100), atlagos_meret varchar(100),legnagyobb_meret varchar(120), cute tinyint,
constraint species_name_pk primary key (species_name),
constraint genus_name_fk foreign key (genus_name) references classification(genus_name));

insert into subclass values ('Orthoceratoidea',1776,1884,1,1,'Ordovician');
insert into subclass values ('Nautiloids',1345,1847,1,0,'Cambrian');
insert into subclass values ('Ammonoidea',300,1884,1,1,'Devonian');
insert into subclass values ('Coleoidea',3462,1884,0,0,'Carboniferous');