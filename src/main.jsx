import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import {BrowserRouter as Router, Routes, Route} from 'react-router-dom'
import Layout from './ui/Layout.jsx'
import Home from './routes/Home.jsx'
import Details from './routes/Details.jsx'
import Purchases from './routes/Purchases.jsx'
import { SearchProvider } from "./SearchContext.jsx";


createRoot(document.getElementById('root')).render(
  <StrictMode>
    <SearchProvider>
    <Router>
    <Routes>
      <Route element={<Layout />}>
        <Route path="/" element={<Home />} />
        <Route path="/details/:id" element={<Details />} />
        <Route path="/purchases/:id" element={<Purchases />} />
      </Route>
    </Routes>
  </Router>
  </SearchProvider>
  </StrictMode>,
)
