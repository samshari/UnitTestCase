import React, {useState} from "react";
import { Modal, Fade } from "@material-ui/core";
import "react-tabs/style/react-tabs.css";
import "../../styles/utils/Card.css";

const CustomModal = (props) => {
  // const [modalOpen, setModalOpen ]= useState(props.open);

  return (
    <Modal
        aria-labelledby="transition-modal-title"
        aria-describedby="transition-modal-description"
        style={{
          display: "flex",
          alignItems: "center",
          justifyContent: "center",
          left: "10%",
          right: "10%",
          top: "6%",
          bottom: "auto",
        }}
        open={props.open}
        onClose={()=> props.close}
        closeAfterTransition
        BackdropProps={{
          timeout: 500,
        }}
      >
        <Fade 
        in={props.open}
        >
          <div
            style={{
              backgroundColor: "white",
              boxShadow:
                "0 1px 15px rgb(0 0 0 / 20%), 0 1px 6px rgb(0 0 0 / 4%)",
              borderRadius: "8px",
              marginTop:"12rem",
              padding: "20px",
              height: "max-content",
            }}
          >
            {props.children}
          </div>
        </Fade>
      </Modal>
  );
};

export default CustomModal;
