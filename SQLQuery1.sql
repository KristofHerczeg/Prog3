
drop table species;
drop table classification;
drop table subclass;
create table subclass(subclass_name VARCHAR(100) , belso_szavazas_eredmenye INT, megtalalas_eve Smallint, external_shell tinyint, kihalt tinyint, megjelenes_idoszaka varchar(40),
constraint subclass_pk primary key (subclass_name));




create table classification(subclass_name varchar(100), order_ varchar(100),family varchar(100),genus_name varchar(100), deep_able tinyint, cthulh_aproved tinyint,special_apparance varchar(120),
constraint genus_name_pk primary key (genus_name), 
constraint subclass_name_fk foreign key (subclass_name) references subclass(subclass_name));  

create table species(species_name varchar(100), felfedezes smallint, megjelenes varchar(20), genus_name varchar(100), atlagos_meret varchar(100),legnagyobb_meret varchar(120), cute tinyint,
constraint species_name_pk primary key (species_name),
constraint genus_name_fk foreign key (genus_name) references classification(genus_name));


insert into subclass values ('Orthoceratoidea',1776,1884,1,1,'Ordovician');

insert into CLASSIFICATION values('Orthoceratoidea','Orthocerida','Baltoceratidae','Metabaltoceras',0,0,'no');

insert into species values('M. fusiforme',1964,'Orvodivician','Metabaltoceras','48mm', '57mm',0);
insert into species values('M. minutum',1964,'Orvodivician','Metabaltoceras','45mm', '52mm',0);

insert into CLASSIFICATION values('Orthoceratoidea','Orthocerida','Baltoceratidae','Cochlioceras',0,0,'no');
insert into CLASSIFICATION values('Orthoceratoidea','Orthocerida','Baltoceratidae','Cyrtobaltoceras',0,0,'no');
insert into CLASSIFICATION values('Orthoceratoidea','Orthocerida','Baltoceratidae','Endorioceras',0,0,'no');

insert into subclass values ('Nautiloids',1345,1847,1,0,'Cambrian');

insert into CLASSIFICATION values('Nautiloids','Nautilida','Nautilidae','Nautilus',1,1,'No');

insert into species values('N. belauensis',1981,'Eocen','Nautilus','200mm', '239mm',0);
insert into species values('M. aranima',1892,'Eocen','Nautilus','180mm', '210mm',0);

insert into CLASSIFICATION values('Nautiloids','Nautilida','Nautilidae','Tarphycerida',0,0,'no');
insert into CLASSIFICATION values('Nautiloids','Nautilida','Nautilidae','Oncocerid',0,0,'no');
insert into CLASSIFICATION values('Nautiloids','Nautilida','Nautilidae','Ellesmerocerida',0,0,'no');
insert into CLASSIFICATION values('Nautiloids','Nautilida','Bactritoidea','Bactritida',0,0,'no');

insert into subclass values ('Ammonoidea',300,1884,1,1,'Devonian');

insert into CLASSIFICATION values ('Ammonoidea','Ammonitida','Graphoceratidae','Graphoceras',0,0,'no');
insert into CLASSIFICATION values ('Ammonoidea','Ammonitida','Ussuritidae','Palaeophyllites',0,0,'no');


insert into subclass values ('Coleoidea',3462,1884,0,0,'Carboniferous');

insert into CLASSIFICATION values('Coleoidea','Oegopsida','Batoteuthidae','Batoteuthis',1,1,'bioluminescens');
insert into CLASSIFICATION values('Coleoidea','Oegopsida','Brachioteuthidae','Brachioteuthis', 0 , 1 ,'bioluminescens');
insert into CLASSIFICATION values('Coleoidea','Oegopsida','Brachioteuthidae','Slosarczykovia', 0 , 1, 'No');
insert into CLASSIFICATION values('Coleoidea','Oegopsida','Cranchiidae','Mesonychoteuthis',1,1,'No');
insert into species values('Colossal squid',1925,'Orvodivician','Mesonychoteuthis','11m', '14m',0);

insert into CLASSIFICATION values('Coleoidea','Oegopsida','Cranchiidae',   'Liocranchia' ,1,1,'No');
insert into species values('Liocranchia gardineri ',1921,'Orvodivician','Liocranchia','6m', '7m',0);
insert into species values('Liocranchia reinhardti',1856,'Orvodivician','Liocranchia','4m', '6,3m',0);
insert into species values('Liocranchia valdiviae',1910,'Orvodivician','Liocranchia','4m', '6m',0);
insert into CLASSIFICATION values('Coleoidea','Oegopsida','Cranchiidae',   'Liguriella' ,1,0,'No');
insert into CLASSIFICATION values('Coleoidea','Oegopsida','Cranchiidae',   'Belonella' ,0,0,'No');
insert into CLASSIFICATION values('Coleoidea','Oegopsida','Cranchiidae',   'Leachia' ,0,1,'No');


insert into CLASSIFICATION values('Coleoidea','Octopoda','Opisthoteuthidae','Opisthoteuthis', 1 ,0,'No');
insert into species values('Flapjack Octopus',2015,'Neogene','Opisthoteuthis','20cm', '26cm',0);
insert into CLASSIFICATION values('Coleoidea','Octopoda','Opisthoteuthidae','Cryptoteuthis', 1 ,0,'No');
insert into CLASSIFICATION values('Coleoidea','Octopoda','Opisthoteuthidae','Grimpoteuthis', 1 ,1,'No');
insert into CLASSIFICATION values('Coleoidea','Octopoda','Opisthoteuthidae','Luteuthis', 1 ,0,'No');






