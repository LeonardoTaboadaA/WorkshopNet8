-- CREATE DATABASE workshop_net8;

-- USE workshop_net8;


-- Create tables
CREATE TABLE categories (
	id INT IDENTITY(1,1),
	name NVARCHAR(200) NOT NULL,
	description NVARCHAR(1000) NULL,
	url_key NVARCHAR(250) NULL,
	state CHAR(1) NOT NULL CONSTRAINT DF_categories_state DEFAULT ('A'),
	created_at DATETIME NOT NULL CONSTRAINT DF_categories_created_at DEFAULT (GETDATE()),
	updated_at DATETIME NULL,
	
	CONSTRAINT categories_pk PRIMARY KEY (id),
	CONSTRAINT categories_name_uq UNIQUE (name)
);

CREATE TABLE products (
	id INT IDENTITY(1,1),
	name NVARCHAR(300) NOT NULL,
	description NVARCHAR(4000) NULL,
	price DECIMAL(18,2) NOT NULL CONSTRAINT DF_products_price DEFAULT (0),
	stock INT NOT NULL CONSTRAINT DF_products_stock DEFAULT (0),
	category_id INT NULL,
	state CHAR(1) NOT NULL CONSTRAINT DF_products_state DEFAULT ('A'),
	created_at DATETIME NOT NULL CONSTRAINT DF_products_created_at DEFAULT (GETDATE()),
	updated_at DATETIME NULL,
	
	CONSTRAINT products_pk PRIMARY KEY (id),
	CONSTRAINT products_category_id_fk FOREIGN KEY (category_id) REFERENCES categories(id),
	CONSTRAINT products_name_subcategory_id_uq UNIQUE (name,category_id)
);

CREATE TABLE profiles (
	id INT IDENTITY(1,1),
	name NVARCHAR(200) NOT NULL,
	description NVARCHAR(1000) NULL,
	state CHAR(1) NOT NULL CONSTRAINT DF_profiles_state DEFAULT ('A'),
	created_at DATETIME NOT NULL CONSTRAINT DF_profiles_created_at DEFAULT (GETDATE()),
	updated_at DATETIME NULL,
	
	CONSTRAINT profiles_pk PRIMARY KEY (id),
	CONSTRAINT profiles_name_uq UNIQUE (name)
);

CREATE TABLE users (
	id INT IDENTITY(1,1),
	name NVARCHAR(200) NOT NULL,
	last_name NVARCHAR(200) NULL,
	email NVARCHAR(100) NOT NULL,
	password NVARCHAR(200) NOT NULL,
	profile_id INT NULL,
	state CHAR(1) NOT NULL CONSTRAINT DF_users_state DEFAULT ('A'),
	created_at DATETIME NOT NULL CONSTRAINT DF_users_created_at DEFAULT (GETDATE()),
	updated_at DATETIME NULL,
	
	CONSTRAINT users_pk PRIMARY KEY (id),
	CONSTRAINT users_profile_id_fk FOREIGN KEY (profile_id) REFERENCES profiles (id),
	CONSTRAINT users_email_uq UNIQUE (email)
);

CREATE TABLE document_types (
	id INT IDENTITY(1,1),
	name NVARCHAR(200) NOT NULL,
	description NVARCHAR(1000) NULL,
	sunat_code NVARCHAR(2) NULL,
	size INT NULL,
	is_size_exact INT NOT NULL CONSTRAINT DF_document_types_is_size_exact DEFAULT (0),
	is_numeric INT NOT NULL CONSTRAINT DF_document_types_is_numeric DEFAULT (0),
	state CHAR(1) NOT NULL CONSTRAINT DF_document_types_state DEFAULT ('A'),
	created_at DATETIME NOT NULL CONSTRAINT DF_document_types_created_at DEFAULT (GETDATE()),
	updated_at DATETIME NULL,
	
	CONSTRAINT document_types_pk PRIMARY KEY (id),
	CONSTRAINT document_types_name_uq UNIQUE (name)
);

CREATE TABLE customers (
	id INT IDENTITY(1,1),
	name NVARCHAR(200) NOT NULL,
	last_name NVARCHAR(200) NULL,
	document_type_id INT NOT NULL,
	document_number NVARCHAR(20) NOT NULL,
	phone_number NVARCHAR(25) NULL,
	address NVARCHAR(2000) NULL,
	state CHAR(1) NOT NULL CONSTRAINT DF_customers_state DEFAULT ('A'),
	created_at DATETIME NOT NULL CONSTRAINT DF_customers_created_at DEFAULT (GETDATE()),
	updated_at DATETIME NULL,
	
	CONSTRAINT customers_pk PRIMARY KEY (id),
	CONSTRAINT customers_document_type_id_fk FOREIGN KEY (document_type_id) REFERENCES document_types (id),
	CONSTRAINT customers_document_type_id_document_number_uq UNIQUE (document_type_id, document_number)
);

CREATE TABLE invoices (
	id INT IDENTITY(1,1),
	invoice_date DATETIME NULL,
	customer_id INT NULL,
	user_id INT NULL,
	state CHAR(1) NOT NULL CONSTRAINT DF_invoices_state DEFAULT ('A'),
	created_at DATETIME NOT NULL CONSTRAINT DF_invoices_created_at DEFAULT (GETDATE()),
	updated_at DATETIME NULL,
	
	CONSTRAINT invoices_pk PRIMARY KEY (id),
	CONSTRAINT invoices_customer_id FOREIGN KEY (customer_id) REFERENCES customers (id),
	CONSTRAINT invoices_user_id FOREIGN KEY (user_id) REFERENCES users (id)
);

CREATE TABLE invoice_details (
	invoice_id INT NOT NULL,
	product_id INT NOT NULL,
	quantity INT NULL,
	price DECIMAL(18,2) NOT NULL,
	state CHAR(1) NOT NULL CONSTRAINT DF_invoice_details_state DEFAULT ('A'),
	created_at DATETIME NOT NULL CONSTRAINT DF_invoice_details_created_at DEFAULT (GETDATE()),
	updated_at DATETIME NULL,
	
	CONSTRAINT invoice_details_pk PRIMARY KEY (invoice_id, product_id),
	CONSTRAINT invoice_details_invoice_id FOREIGN KEY (invoice_id) REFERENCES invoices (id),
	CONSTRAINT invoice_details_product_id FOREIGN KEY (product_id) REFERENCES products (id)
);