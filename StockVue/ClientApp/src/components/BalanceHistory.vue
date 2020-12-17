<template>
    <div class="container">
        <LineChart v-if="isLoaded"
                    :chart-data="data"
                    :chart-labels="labels"
                    :options="options" />
    </div>
</template>

<script>
    import LineChart from '@/components/LineChart.vue'
    import axios from 'axios';

    export default {
        name: 'BalanceHistory',
        components: { LineChart },
        props: {},
        data() {
            return {                
                options: null,                
            }
        },        
        computed: {
            data() {
                return this.$store.state.history.data;
            },
            labels() {
                return this.$store.state.history.labels;
            },
            isLoaded() {
                return this.$store.state.history.data.length > 0;
            }
        }


    }
</script>