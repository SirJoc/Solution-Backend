CREATE  DATABASE Test;

USE Test;

CREATE TABLE cloths (
id int NOT NULL AUTO_INCREMENT,
color varchar(30) NOT NULL,
brand varchar(30) NOT NULL,
PRIMARY KEY(id)
);

CREATE  TABLE orders (
id int NOT NULL AUTO_INCREMENT,
cloth_id int,
constraint f_k_orders_cloths_cloth_id
foreign key(cloth_id) references cloths(id)	on delete cascade,
PRIMARY KEY(id)
);


CREATE TABLE order_details (
id int NOT NULL AUTO_INCREMENT,
cloth_id int,
order_id int,
constraint f_k_order_details_cloths_cloth_id
foreign key(cloth_id) references cloths(id) on delete cascade,

constraint f_k_order_details_orders_order_id
foreign key(order_id) references orders(id) on delete cascade,
PRIMARY KEY(id)
);