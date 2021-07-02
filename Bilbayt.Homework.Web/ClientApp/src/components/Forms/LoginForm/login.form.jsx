import { Link } from "react-router-dom";

import { FormContainer } from "../../Container/AuthContainer.styles";
import FormInput from "../../UIs/FormInput/FormInput.ui";
import ButtonOrange from "../../UIs/ButtonOrange/ButtonOrange.ui";

import routes from "../../../configs/routes";

const LoginForm = () => {
  return (
    <FormContainer>
      <div className="form-group">
        <FormInput className="form-control" placeholder="UserName" />
      </div>
      <div className="form-group d-inline">
        <FormInput
          className="form-control d-inline"
          placeholder="Password"
          type="password"
          showable={true}
        />
      </div>
      <div className="d-flex justify-content-between align-items-center">
        <ButtonOrange>Login</ButtonOrange>
        <span className="special-text">
          Don't have an account , Please{" "}
          <Link className="text-orange" to={routes.signup}>
            {" "}
            Sign Up
          </Link>
        </span>
      </div>
    </FormContainer>
  );
};

export default LoginForm;
