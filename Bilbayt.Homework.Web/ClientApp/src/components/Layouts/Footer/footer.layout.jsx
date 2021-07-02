import {
  FooterContainer,
  FooterCopyright,
  FooterContent,
  FooterCopyrightName,
  FooterCopyrightText,
} from "./footer.styles";
const Footer = () => {
  return (
    <FooterContainer>
      <div className="container-fluid">
        <div className="row">
          <div className="col-md-12">
            <FooterContent>
              <FooterCopyright>
                <FooterCopyrightName>Bilbayt Homework</FooterCopyrightName>
                <FooterCopyrightText>&copy; 2021</FooterCopyrightText>
              </FooterCopyright>
            </FooterContent>
          </div>
        </div>
      </div>
    </FooterContainer>
  );
};

export default Footer;
