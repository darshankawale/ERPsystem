CREATE TABLE accounts (
    account_id INT IDENTITY PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    type VARCHAR(20) NOT NULL CHECK (type IN ('Asset', 'Liability', 'Equity', 'Income', 'Expense')),
    parent_id INT NULL,
    description TEXT,
    FOREIGN KEY (parent_id) REFERENCES accounts(account_id)
);

CREATE TABLE transactions (
    transaction_id INT IDENTITY PRIMARY KEY,
    account_id INT NOT NULL,
    date DATE NOT NULL,
    description TEXT,
    amount DECIMAL(12,2) NOT NULL,
    type VARCHAR(10) NOT NULL CHECK (type IN ('debit', 'credit')),
    related_id INT NULL,
    FOREIGN KEY (account_id) REFERENCES accounts(account_id)
);

CREATE TABLE invoices (
    invoice_id INT IDENTITY PRIMARY KEY,
    customer_name VARCHAR(100) NOT NULL,
    issue_date DATE NOT NULL,
    due_date DATE NULL,
    subtotal DECIMAL(12,2),
    tax_rate DECIMAL(5,2),
    total_amount DECIMAL(12,2),
    status VARCHAR(10) DEFAULT 'draft' CHECK (status IN ('draft', 'sent', 'paid', 'overdue'))
);

CREATE TABLE invoice_items (
    item_id INT IDENTITY PRIMARY KEY,
    invoice_id INT NOT NULL,
    description TEXT,
    quantity INT,
    unit_price DECIMAL(10,2),
    tax_percent DECIMAL(5,2),
    total DECIMAL(12,2),
    FOREIGN KEY (invoice_id) REFERENCES invoices(invoice_id)
);


CREATE TABLE budgets (
    budget_id INT PRIMARY KEY Identity,
    account_id INT NOT NULL,
    fiscal_year INT,
    allocated DECIMAL(12,2),
    spent DECIMAL(12,2) DEFAULT 0,
    remaining DECIMAL(12,2),
    FOREIGN KEY (account_id) REFERENCES accounts(account_id)
);

CREATE TABLE reports (
    report_id INT IDENTITY PRIMARY KEY,
    type VARCHAR(20) CHECK (type IN ('P&L', 'BalanceSheet')),
    period_start DATE,
    period_end DATE,
    created_at DATETIME DEFAULT GETDATE(),
    file_path VARCHAR(255)
);

