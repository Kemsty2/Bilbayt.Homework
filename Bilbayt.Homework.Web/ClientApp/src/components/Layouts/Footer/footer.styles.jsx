import styled from "styled-components";

export const FooterContainer = styled.footer`
  background-color: #f8f8f8;
  padding-bottom: 50px;
`;

export const FooterContent = styled.div`
  width: 100%;
  max-width: 723px;
  margin: 0 auto;
  display: flex;
  justify-content: space-between;
  align-items: center;
  border-top: 1px solid #ccc;
  padding-top: 25px;

  @media screen and (max-width: 767px) {
    max-width: unset;
  }

  @media screen and (max-width: 375px) {
    flex-direction: column-reverse;
  }
`;

export const FooterCopyright = styled.div`
  @media screen and (max-width: 375px) {
    margin-top: 25px;
    text-align: center;
  }

  h6 {
    font-size: 24px;
    margin-bottom: 5px;
  }
`;

export const FooterCopyrightName = styled.h6`
  font-size: 24px;
  margin-bottom: 5px;
`;

export const FooterCopyrightText = styled.p`
  margin-bottom: 0;
  font-size: 16px;
  color: rgba(0, 0, 0, 0.67);
`;
