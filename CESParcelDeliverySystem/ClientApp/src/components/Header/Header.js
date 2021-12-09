import React from "react";
import AppBar from "@material-ui/core/AppBar";
import Toolbar from "@material-ui/core/Toolbar";
import Button from "@material-ui/core/Button";
import Badge from "@material-ui/core/Badge";
import MenuIcon from "@material-ui/icons/Menu";
import NotificationsIcon from "@material-ui/icons/Notifications";
import PersonIcon from "@material-ui/icons/Person";
import Typography from "@material-ui/core/Typography";
import { withStyles } from "@material-ui/core/styles";
import { Link } from "react-router-dom";

const styles = theme => ({
  toolbarRoot: {
    paddingRight: 24
  },
  menuButton: {
    marginLeft: 12,
    marginRight: 36
  },
  title: {
    flexGrow: 1
  }
});

const Header = props => {
  const { classes, handleToggleDrawer } = props;
  return (
    <AppBar position="fixed">
      <Toolbar disableGutters={true} classes={{ root: classes.toolbarRoot }}>
        <Typography
          variant="h6"
          color="inherit"
          noWrap
          className={classes.title}
        >
        </Typography>
        <Link to="/plan-route">
        <Button color="secondary">
          Plan Route
        </Button>
        </Link>
        <Link to="/manage-location">
        <Button color="inherit">
          Manage Location
        </Button>
        </Link>
        <Link to="/manage-price">
        <Button color="inherit">
          Manage Price
        </Button>
        </Link>
        <Link to="/export-data">
        <Button color="inherit">
          Export Data
        </Button>
        </Link>
      </Toolbar>
    </AppBar>
  );
};

export default withStyles(styles)(Header);
