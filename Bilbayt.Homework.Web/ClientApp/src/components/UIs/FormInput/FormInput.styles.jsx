import styled from "styled-components";

export const Input = styled.input`
  background: #e0e0e0;
  border-radius: 3px;
  border: 2px solid #e0e0e0;
  outline: none;

  &::placeholder {
    color: #6e6d7a;
    font-weight: bold;
    font-size: 14px;
  }

  &:focus {
    background-color: #fff;
    border: 1px solid #e0e0e0;
    box-shadow: unset;
  }

  ${(props) => {
    if (props.type === "password") {
      return `       
        font-weight: normal;
  
        &:disabled {
          cursor: no-drop;
        }`;
    }
  }}

  ${(props) => {
    if (props.invalid) {
      return `      
        border: 1px solid #cd3c14;    
        &:focus {
          border: 1px solid #cd3c14;  
        }  
      `;
    }
  }}
`;

export const PasswordIcon = styled.div`
  position: relative;
  bottom: 40px;
  left: 370px;
  width: auto;
  display: inline-block;
`;
