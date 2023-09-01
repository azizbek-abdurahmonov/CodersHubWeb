import React from "react";
import Box from '@mui/material/Box';
import Modal from '@mui/material/Modal';
import { Alert } from "@mui/material";

const style = {
  position: 'absolute',
  top: '50%',
  left: '50%',
  transform: 'translate(-50%, -50%)',
  width: 700,
  bgcolor: 'background.paper',
  boxshadow: "rgba(0, 0, 0, 0.16), 0px 10px 36px 0px, rgba(0, 0, 0, 0.06) 0px 0px 0px 1px",
  p: 4,
};

export default class ModalComponent extends React.Component{
    constructor(props){
        super(props);
        this.state={
            opened: false
        };
    }
    handleClose = () =>{
        this.setState({opened: false})
    }
    handleOpen = () =>{
        this.setState({opened: true})
    }
    completed=(cond)=>{
        var r = cond();
        if (r) {this.handleClose();this.setState({errorMessage: undefined})}
        else this.setState({errorMessage: "Error: Please check credentials"})
    }
    render(){
        return(
            <>
            <button onClick={this.handleOpen}>{this.props.buttonChild}</button>
            <Modal
            open={this.state.opened}
            onClose={this.handleClose}
            aria-labelledby="modal-modal-title"
            aria-describedby="modal-modal-description"
            >
            <Box sx={style}>
                {this.props.modalContent}
                <hr/>
                {
                    this.errorMessage?<Alert severity="error">{this.state.errorMessage}</Alert>:<></>
                }
                <div style={{display: "flex",flexDirection: "row",justifyContent: "center"}}>
                    <button style={{width: "300px"}} onClick={this.props.handleCompButton}>{this.props.compButtonText}</button>
                </div>
                
            </Box>
            </Modal>
            </>
        )
    }
}