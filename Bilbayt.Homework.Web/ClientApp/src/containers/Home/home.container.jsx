import { connect } from "react-redux";
import { createStructuredSelector } from "reselect";

import HomePage from "../../pages/Home/home.page";
import { selectUserProfile } from "../../store/reducers/users/users.selectors";

const HomeContainer = ({ profile }) => {
  return <HomePage profile={profile} />;
};

const mapStateToProps = createStructuredSelector({
  profile: selectUserProfile,
});

export default connect(mapStateToProps)(HomeContainer);
