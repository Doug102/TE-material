SELECT tr.transfer_id AS TransferId, tr.account_from AS Account,
tr.account_to AS AccountTo, tr.amount AS Amount, tt.transfer_type_desc AS TransferType, 
        ts.transfer_status_desc AS TransferStatus FROM transfers tr  
        JOIN transfer_statuses ts ON ts.transfer_status_id = tr.transfer_status_id
        JOIN transfer_types tt ON tt.transfer_type_id = tr.transfer_type_id
        WHERE account_from = 3000 OR account_to = 3000 AND ts.transfer_status_id = 2000
