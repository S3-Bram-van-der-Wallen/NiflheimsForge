<script lang="ts">
    import { Button } from '@sveltestrap/sveltestrap';
</script>
  
<style>
    .center {
      margin: auto;
      width: 50%;
      padding: 10px; 
      text-align: center;
    }
  
    .button-text {
      font-size: 2rem;
    }
  </style>

<div class="center">
    <Button href="countries" color="success">
        <span class="button-text">See your Countries</span>
    </Button>
</div>  