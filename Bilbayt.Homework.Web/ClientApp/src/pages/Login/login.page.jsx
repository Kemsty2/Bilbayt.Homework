import { AuthFormContainer } from "../../components/Container/AuthContainer.styles";
import { AuthTitle, AuthSubTitle, AuthText } from "./login.styles";
import LoginForm from "../../components/Forms/LoginForm/login.form";

const LoginPage = () => {
  return (
    <AuthFormContainer>
      <AuthTitle>Login</AuthTitle>
      <AuthSubTitle>Login to Bilbayt Homework</AuthSubTitle>
      <AuthText>Please enter your credentials to continue</AuthText>

      <LoginForm />
    </AuthFormContainer>
  );
};

export default LoginPage;
