import { useEffect,useState } from 'react';
import {Link, useParams} from 'react-router-dom'

function Details() {
    const {id} = useParams()

    //Define a state variable to hold events
            const [Activites,setActivites] = useState(null)
        
            //Get API URL from enviroment variable
           const apiUrl = import.meta.env.VITE_Activites_API_URL;
           const baseUrl = import.meta.env.VITE_Backend_URL;
        
           //fetch events from api when componet mounts
            useEffect(() => {
                const getActivitesById = async () => {
                const response = await fetch(`${apiUrl}/${id}`)
                const result = await response.json()
        
                if(response.ok) {
                    setActivites(result)
                }
            }
                getActivitesById()
        
            
            }, [])
             if (!Activites) return <p className="text-center mt-5">Loading...</p>;

             const imagePath = Activites.ImageFilename ? `${baseUrl}/images/${Activites.ImageFilename}` : "/placeholder.png";
     return (
    <div className="container my-4">

      <Link to="/" className="btn btn-outline-secondary mb-3">Back to Home
      </Link>

      <div className="card shadow">
        <img 
          src={imagePath} className="card-img-top" alt={Activites.ActivitesTitle} />

        <div className="card-body">
          <h2>{Activites.ActivitesTitle}</h2>

          <p><strong>Description:</strong> {Activites.Description}</p>
          <p><strong>Location:</strong> {Activites.Location}</p>
          <p><strong>Category:</strong> {Activites.CategoryTitle}</p>
          <p><strong>Owner:</strong> {Activites.Owner}</p>

          <Link 
            to={`/purchases/${id}`} 
            className="btn btn-primary w-100 mt-3">Buy Ticket</Link>
        </div>
      </div>
    </div>
  );
}

export default Details;