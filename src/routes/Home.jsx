import { useEffect,useState, useContext } from "react"
import PhotoCard from '../ui/PhotoCard'
import { SearchContext } from "../SearchContext"

function Home(){
      //Define a state variable to hold events
        const [Activites,setActivites] = useState([])
        const { search } = useContext(SearchContext)
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
        const filtered = Activites.filter(ev => 
            ev.ActivitesTitle.toLowerCase().includes(search.toLowerCase())
  )
    return(
          <>
           <div className="container-fluid p-0">
            <div className="banner-hero d-flex justify-content-center align-items-center">
            <h1 className="text-white fw-bold display-4 text-shadow">
                EVENTS & TICKETS
            </h1>
            </div>
        </div>

        <div className="photo-grid">

        {
            filtered.length > 0 && (
                    filtered.map(event => (
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