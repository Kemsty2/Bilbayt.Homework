import { NavLink } from "react-router-dom";

import routes from "../../../configs/routes";
import { SubHeaderContainer, SubHeaderContent } from "./subheader.styles";

const SubHeader = () => {
  return (
    <SubHeaderContainer className="shadow-sm">
      <div className="container">
        <SubHeaderContent
          role="navigation"
          className="o-nav-local navbar-light"
        >
          <ul className="container nav mt-auto">
            <li className="nav-item">
              <NavLink
                to={routes.home}
                className="nav-link"
                activeClassName="active"
              >
                My profile
              </NavLink>
            </li>
          </ul>
        </SubHeaderContent>
      </div>
    </SubHeaderContainer>
  );
};

export default SubHeader;
