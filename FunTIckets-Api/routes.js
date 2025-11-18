import express from 'express';
import sql from 'mssql';
import 'dotenv/config';

const router = express.Router();

// get connection string from environment variable
const dbConnectionString = process.env.dbConnectionString;
// GET: /api/photos
router.get('/', async (req, res) => {
  
    // make sure that any items are correctly URL encoded in the connection string
    await sql.connect(dbConnectionString);
    
    const result = await sql.query`SELECT a.[ActiviteId], a.[ActiviteName] as ActivitesTitle, a.[Description], a.[ImageFilename], a.[CreatedAt], a.[Owner], a.[Location], b.[CategoryId], b.[CategoryName] as CategoryTitle
        from [dbo].[Activites] a 
        INNER JOIN [dbo].[Categories] b 
        ON a.[CategoryId] = b.[CategoryId]
        ORDER BY a.[CreatedAt] DESC`;
    
   res.json(result.recordsets[0]);
 });


 // GET: /api/photos/1
router.get('/:id', async (req, res) => {
    const id = req.params.id;

    if(isNaN(id)) {
        res.status(400).send('Invalid event ID.');
        return;
    }

    // make sure that any items are correctly URL encoded in the connection string
    await sql.connect(dbConnectionString);
    
    const result = await sql.query`SELECT a.[ActiviteId], a.[ActiviteName] as ActivitesTitle, a.[Description], a.[ImageFilename], a.[CreatedAt], a.[Owner], a.[Location], b.[CategoryId], b.[CategoryName] as CategoryTitle
        from [dbo].[Activites] a 
        INNER JOIN [dbo].[Categories] b 
        ON a.[CategoryId] = b.[CategoryId]
        WHERE a.[ActiviteId] = ${id}`;
    
    // return the results as json
    if(result.recordset.length === 0) {
        res.status(404).json({ message: 'Event not found.'});        
    }
    else {
        res.json(result.recordset); 
    }
});

 export default router;
