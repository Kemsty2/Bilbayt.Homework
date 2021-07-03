import React from "react";
import { Route, Redirect } from "react-router-dom";
import { connect } from "react-redux";
import { createStructuredSelector } from "reselect";

import { selectUserProfile } from "../../../store/reducers/users/users.selectors";

import { isEmpty } from "../../../utils";

const PublicRoute = ({ component: Component, profile, ...rest }) => {
  return (
    <Route
      {...rest}
      render={(props) =>
        !isEmpty(profile) ? <Redirect to="/" /> : <Component {...props} />
      }
    />
  );
};

const mapStateToProps = createStructuredSelector({
  profile: selectUserProfile,
});

export default connect(mapStateToProps)(PublicRoute);
