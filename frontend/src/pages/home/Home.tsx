import React from "react";
import "./home.scss";
import { Button } from "@mui/material";
import { useNavigate } from "react-router-dom";
import catImage from "../../asset/Cat_Image.jpg";

const Home = () => {
  const redirect = useNavigate();

  return (
    <div className="home">
      <h1>Welcome To Pet Store</h1>
      <Button
        variant="outlined"
        color="primary"
        onClick={() => redirect("/products")}
      >
        Products List
      </Button>

      <img src={catImage} />
    </div>
  );
};

export default Home;
