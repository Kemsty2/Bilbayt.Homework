import Icon from "@iconify/react";
import { connect } from "react-redux";

import caretDown from "@iconify/icons-fa-solid/caret-down";
import {
  HeaderContainer,
  NavBarContainer,
  NavBarContent,
  AvatarIcon,
  AvatarName,
  DropDownMenu,
  DropDownMenuInfo,
  DropDownMenuInfoName,
  DropDownMenuInfoEmail,
  DropDownItemLink,
  DropDownItemButton,
} from "./header.styles";
import LogoBrand from "../../UIs/LogoBrand/logobrand.ui";
import routes from "../../../configs/routes";
import { createStructuredSelector } from "reselect";
import { selectUserProfile } from "../../../store/reducers/users/users.selectors";
import { logout } from "../../../store/reducers/users/users.action";

const Header = ({ profile, logout }) => {
  const handleLogout = (e) => {
    e.preventDefault();

    logout();
  };

  return (
    <HeaderContainer className="fixed-top">
      <NavBarContainer
        role="navigation"
        className="navbar navbar-expand-sm navbar-light"
      >
        <NavBarContent className="container-fluid">
          <button
            className="navbar-toggler"
            type="button"
            data-toggle="collapse"
            data-target="#navbarSupportedContent"
            aria-controls="navbarSupportedContent"
            aria-expanded="false"
            aria-label="Toggle navigation"
          >
            <span className="navbar-toggler-icon"></span>
          </button>

          <div className="collapse navbar-collapse" id="navbarSupportedContent">
            <a className="navbar-brand" href="#">
              <LogoBrand className="text-black" imageClassName="mr-1" />
            </a>

            <div className="ml-auto my-2 my-lg-0">
              <div className="dropdown">
                <a
                  className="nav-link custom-dropdown-toggle"
                  href="#!"
                  id="profile"
                  role="button"
                  data-toggle="dropdown"
                  aria-haspopup="true"
                  aria-expanded="false"
                >
                  <AvatarIcon>J</AvatarIcon>
                  <AvatarName> Hello, {profile.fullName} </AvatarName>
                  <Icon icon={caretDown} />
                </a>
                <DropDownMenu className="dropdown-menu">
                  <DropDownMenuInfo>
                    <DropDownMenuInfoName>
                      {profile.fullName}
                    </DropDownMenuInfoName>
                    <DropDownMenuInfoEmail>
                      {profile.userName}
                    </DropDownMenuInfoEmail>
                  </DropDownMenuInfo>
                  <DropDownItemLink className="dropdown-item" to={routes.home}>
                    {" "}
                    My Profile
                  </DropDownItemLink>

                  <DropDownItemButton
                    className="dropdown-item"
                    onClick={handleLogout}
                  >
                    {" "}
                    Sign out{" "}
                  </DropDownItemButton>
                </DropDownMenu>
              </div>
            </div>
          </div>
        </NavBarContent>
      </NavBarContainer>
    </HeaderContainer>
  );
};
const mapStateToProps = createStructuredSelector({
  profile: selectUserProfile,
});

const mapDispatchToProps = (dispatch) => ({
  logout: () => dispatch(logout()),
});

export default connect(mapStateToProps, mapDispatchToProps)(Header);
