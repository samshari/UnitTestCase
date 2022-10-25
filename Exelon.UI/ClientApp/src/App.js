import React, { useEffect } from "react";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import Header from "./js/views/Header";
import Navbar from "./js/views/Navbar";
import Masters from "./js/components/Masters";
import Engineering from "./js/components/Engineering";
import HutPermitting from "./js/components/HutPermitting";
import HutsExecution from "./js/components/HutsExecution";
import Huts from "./js/components/Huts";
import ExecutionLinks from "./js/components/ExecutionLinks";
import Demo from "./js/components/Demo";

function App() {
  const user_role = "general";
  //   window.onbeforeunload = function() {
  //     const value=localStorage.getItem("selectedNavbarItem")
  //     value !== 1 && (localStorage.setItem("selectedNavbarItem", 1))
  //  }
  useEffect(() => {
    fetch(
      `https://api.foursquare.com/v2/venues/explore?near=ashkelon&v=20180729&client_id=MVLZGLPIAITJITM0OOFYER3C2ZRT5ERGGEWCC0T1YWV3HFZA&client_secret=1TBLTY0TSM1T320FEO3BJBGTMYVQPCMBOGO5GEBC0ZB1E5LK`
    ).then((res)=>{
      console.log("res", res)
    })
  }, []);
  return (
    <BrowserRouter>
      <Header userRole={user_role} />
      <Navbar />
      {/* <Navbar2/> */}
      <Routes>
        <Route exact path="/Admin" element={<Masters />} />
        <Route exact path="/" element={<Engineering />} />
        <Route exact path="/HutPermitting" element={<HutPermitting />} />
        <Route exact path="/Huts" element={<Huts />} />
        <Route exact path="/HutsExecution" element={<HutsExecution />} />
        <Route exact path="/ExecutionLinks" element={<ExecutionLinks />} />
        <Route exact path="/Demo" element={<Demo />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
