import React from "react";
import { Router, Route, hashHistory } from 'react-router';
import LinkInformation from "./Engineering/LinkInformation";

const Routes=()=>{
    return(
        <Router history={hashHistory} >
            <Route path='/LinkInformation' component={LinkInformation} />
        </Router>
    )
}

export default Routes;