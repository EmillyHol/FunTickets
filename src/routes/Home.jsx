import { useEffect,useState } from "react"
import PhotoCard from '../ui/PhotoCard'

function Home(){
      //Define a state variable to hold events
        const [Activites,setActivites] = useState([])
    
        //Get API URL from enviroment variable
       const apiUrl = import.meta.env.VITE_Activites_API_URL;
    
       //fetch events from api when componet mounts
        useEffect(() => {
            const getActivites = async () => {
            const response = await fetch(apiUrl)
            const result = await response.json()
    
            if(response.ok) {
                setActivites(result)
            }
        }
            getActivites()
    
        
        }, [])
    return(
          <>
        <div className="photo-grid">

        {
            Activites.length > 0 && (
                    Activites.map(event => (
                       <div key={event.ActiviteId} >
                        <PhotoCard ActiviteId={event.ActiviteId} ImageFilename={event.ImageFilename} ActivitesTitle={event.ActivitesTitle} />
                       </div> 
                    ))
            )
        }
    </div>
        </>

    )
}
export default Home