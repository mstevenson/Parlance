Shader "UnlitColor" {
	Properties {
		_Color ("Text Color", Color) = (1,1,1,1) 
	}

	Category {
		SubShader {
			Pass {
				Lighting Off
				Color [_Color]
			}
		}
	}
}