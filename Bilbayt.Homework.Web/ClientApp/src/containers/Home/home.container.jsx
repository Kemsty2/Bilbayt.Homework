import { connect } from "react-redux";
import { createStructuredSelector } from "reselect";
import { useEffect, useState } from "react";

import { getProfileAsync } from "../../store/reducers/users/users.action";

import HomePage from "../../pages/Home/home.page";
import { selectUserProfile } from "../../store/reducers/users/users.selectors";

import Spinner from "../../components/Loaders/spinner/spinner.component";

const HomeContainer = ({ profile, getProfileAsync }) => {
  const [isLoading, setIsLoading] = useState(false);

  useEffect(() => {
    setIsLoading(true);
    getProfileAsync()
      .then(() => {
        setIsLoading(false);
      })
      .catch(() => {
        setIsLoading(false);
      });
  }, []);

  return !isLoading ? <HomePage profile={profile} /> : <Spinner />;
};

const mapStateToProps = createStructuredSelector({
  profile: selectUserProfile,
});

export default connect(mapStateToProps, { getProfileAsync })(HomeContainer);
