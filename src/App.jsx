import { useEffect,useState } from "react";


function App() {

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

        console.log(Activites)
    }, [])
    return(
        <>
            <h1>Fun Events</h1>

        {
            Activites.length > 0 && (

                    Activites.map(event => (
                        <div key={event.ActiviteId} className="masonry-grid-item">
                            <img src={event.ImageFilename} alt={event.ActivitesTitle} className="img-fluid"/>
                        </div>
                    ))
            )
        }

        </>
    )
}

export default App