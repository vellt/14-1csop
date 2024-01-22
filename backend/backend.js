const express = require('express');
const cors= require('cors');
const mysql= require('mysql');
const app= express();

const host ='localhost';
const port= 3000;

app.use(cors());
app.use(express.json());

var connection= mysql.createConnection({
    host: host,
    user: 'root',
    password: '',
    database: 'dot_net'
});

app.get('/users', (req, res)=>{
    connection.query('SELECT * FROM users', (err, results)=>{
        if(err){
            console.log(err);
            res.send("hiba");
        }else{
            console.log(results);
            res.send(results);
        }
    });
});

app.post('/users', (req, res)=>{
    const {firstname, lastname, date, email}=req.body;
    console.log(firstname, lastname, date, email);

    connection.query('INSERT INTO users (id, firstname, lastname, date, email) VALUES (null, ?, ?, ?, ?)', 
    [firstname, lastname, date, email], (err, results)=>{
        if(err){
            console.log(err);
            res.send("hiba");
        }else{
            console.log(results);
            res.send("Sikeres felvitel!");
        }
    });
});

app.delete('/users', (req, res)=>{
    const id= req.body.id;
    console.log(id);

    connection.query('DELETE FROM users WHERE id=?', [id], (err, results)=>{
        if(err){
            console.log(err);
            res.send("hiba");
        }else{
            console.log(results);
            res.send("Sikeres Törlés!");
        }
    });
});

app.put('/users', (req, res)=>{
    const {id, firstname, lastname, date, email}= req.body;
    console.log(id, firstname, lastname, date, email);

    let updateFields=[];
    let updateValues=[];

    if(firstname!=undefined){
        updateFields.push('firstname=?');
        updateValues.push(firstname);
    }

    if(lastname!=undefined){
        updateFields.push('lastname=?');
        updateValues.push(lastname);
    }

    if(date!=undefined){
        updateFields.push('date=?');
        updateValues.push(date);
    }

    if(email!=undefined){
        updateFields.push('email=?');
        updateValues.push(email);
    }

    const updateQuery=`UPDATE users SET ${updateFields.join(', ')} WHERE id=?`;

    connection.query(updateQuery, [...updateValues, id], (err, results)=>{
        if(err){
            console.log(err);
            res.send("hiba");
        }else{
            console.log(results);
            res.send("Sikeres Módosítás!");
        }
    });

    
});

app.listen(port, host, ()=>{
    console.log(`IP: http://${host}:${port}`);
});