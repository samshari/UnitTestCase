import React from "react";

import IconButton from "@material-ui/core/IconButton";

import Snackbar from "@material-ui/core/Snackbar";

import { FaWindowClose } from "react-icons/fa";



export default function CustomSnackBar(props) {

return (

    <div style={{}}>

    <Snackbar

        anchorOrigin={{

        horizontal: "center",

        vertical: "bottom",

        }}

        open={props.open}

        autoHideDuration={2000}

        message={props.message}

        onClose={props.onClose}

        style={{backgroundColor:"lightgray"}}

        action={

        <React.Fragment>

            <IconButton

            size="small"

            aria-label="close"

            color="inherit"

            onClick={props.onClose}

            >

            <FaWindowClose fontSize="small" />

            </IconButton>

        </React.Fragment>

        }

    />

    </div>

);

}