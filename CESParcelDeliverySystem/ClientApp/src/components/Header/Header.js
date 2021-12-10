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
    <AppBar position="fixed" color='secondary'>
      <Toolbar disableGutters={true} classes={{ root: classes.toolbarRoot }}>
        <Typography
          variant="h6"
          color="inherit"
          noWrap
          className={classes.title}
        >
        </Typography>
        <Link to="/plan-a-route" style={{ textDecoration: 'none' }}>
        <Button variant='contained' color="primary">
          Plan Route
        </Button>
        </Link>
        <Link to="/manage-location" style={{ textDecoration: 'none' }}>
        <Button variant='contained' color="primary">
          Manage Location
        </Button>
        </Link>
        <Link to="/manage-price" style={{ textDecoration: 'none' }}>
        <Button variant='contained' color="primary">
          Manage Price
        </Button>
        </Link>
      </Toolbar>
    </AppBar>
  );
};

export default withStyles(styles)(Header);
