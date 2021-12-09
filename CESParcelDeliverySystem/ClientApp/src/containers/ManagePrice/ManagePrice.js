import React from "react";
import Button from "@material-ui/core/Button";
import Card from "@material-ui/core/Card"
import CardContent from "@material-ui/core/CardContent";
import CardActions from "@material-ui/core/CardActions";
import Typography from "@material-ui/core/Typography";

import { useSelector, useDispatch } from "react-redux";

export default function ManagePrice() {


  const dispatch = useDispatch();

  return (
    <div
      style={{
        display: "flex",
        alignItems: "center",
        justifyContent: "center"
      }}
    >
      <Card>
        <CardContent>
          Manage Price
        </CardContent>
        <CardActions>
        </CardActions>
      </Card>
    </div>
  );
};